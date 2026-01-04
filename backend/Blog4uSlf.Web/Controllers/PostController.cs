using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Domain.Models.Posts;
using Blog4uSlf.Web.Dtos.Common.Page;
using Blog4uSlf.Web.Dtos.Posts;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blog4uSlf.Web.Controllers;

/// <summary>
/// Controller for managing blog posts.
/// Provides endpoints for retrieving, creating, updating, and deleting posts.
/// </summary>
[ApiController]
[Route("api/v1/posts")]
public class PostController(IPostService postService) : ControllerBase
{
  private readonly IPostService _postService = postService;

  /// <summary>
  /// Retrieves post by ID.
  /// </summary>
  /// <param name="ct">Cancellation token</param>
  /// <param name="id">Identifier of a post</param>
  /// <response code="200">Post retrieved successfully.</response>
  /// <response code="404">Post not found.</response>
  /// <response code="500">Internal server error.</response>
  [HttpGet("{id:guid}")]
  [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PostDto), description: "Post retrieved successfully.")]
  [SwaggerResponse(StatusCodes.Status404NotFound, description: "Post not found.")]
  [SwaggerResponse(StatusCodes.Status500InternalServerError, description: "Internal server error.")]

  public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
  {
    var post = await _postService.GetByIdOrThrowNotFoundErrorAsync(id, ct);

    return Ok(post.Adapt<PostDto>());
  }

  /// <summary>
  /// Retrieves post page with pagination params.
  /// </summary>
  /// <param name="pageQueryParamsDto">Pagination query params</param>
  /// <param name="ct">Cancellation token</param>
  /// <response code="200">Post retrieved successfully.</response>
  /// <response code="500">Internal server error.</response>
  [HttpGet("page")]
  [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PageDto<PostDto>), description: "Get posts' page retrieved successfully.")]
  [SwaggerResponse(StatusCodes.Status500InternalServerError, description: "Internal server error.")]
  public async Task<IActionResult> GetPostPage([FromQuery] PostPaginationPageQueryParamsDto pageQueryParamsDto, CancellationToken ct)
  {
    var paginationParams = pageQueryParamsDto.Adapt<PostPaginationPageQueryParams>();
    var page = await _postService.GetPageAsync(paginationParams, ct);
    var pageDto = page.Adapt<PageDto<PostDto>>();

    return Ok(pageDto);
  }

  /// <summary>
  /// Creates a new post.
  /// </summary>
  /// <param name="postDto">PostDto params</param>
  /// <param name="ct">Cancellation token</param>
  /// <response code="201">Post created successfully.</response>
  /// <response code="500">Internal server error.</response>
  [HttpPost]
  [SwaggerResponse(StatusCodes.Status201Created, type: typeof(PostDto), description: "Post created successfully.")]
  [SwaggerResponse(StatusCodes.Status500InternalServerError, description: "Internal server error.")]
  public async Task<IActionResult> Create([FromBody] PostCreateDto postDto, CancellationToken ct)
  {
    var post = postDto.Adapt<Post>();
    var created = await _postService.CreateAsync(post, ct);

    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.Adapt<PostDto>());
  }

  /// <summary>
  /// Updates an existing post.
  /// </summary>
  /// <param name="id">Identifier of the post</param>
  /// <param name="postDto">Post dto params</param>
  /// <param name="ct">Cancellation token</param>
  /// <response code="200">Post updated successfully.</response>
  /// <response code="404">Post not found.</response>
  /// <response code="500">Internal server error.</response>
  [HttpPut("{id:guid}")]
  [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PostDto), description: "Post updated successfully.")]
  [SwaggerResponse(StatusCodes.Status404NotFound, description: "Post not found.")]
  [SwaggerResponse(StatusCodes.Status500InternalServerError, description: "Internal server error.")]
  public async Task<IActionResult> UpdatePostById([FromRoute] Guid id, [FromBody] PostUpdateDto postDto, CancellationToken ct)
  {
    var post = postDto.Adapt<Post>();
    var updated = await _postService.UpdateByIdAsync(id, post, ct);

    return Ok(updated.Adapt<PostDto>());
  }

  /// <summary>
  /// Deletes an existing post.
  /// </summary>
  /// <param name="id">Identifier of the post</param>
  /// <param name="ct">Cancellation token</param>
  /// <response code="204">Post deleted successfully.</response>
  /// <response code="404">Post not found.</response>
  /// <response code="500">Internal server error.</response>
  [HttpDelete("{id}")]
  [SwaggerResponse(StatusCodes.Status204NoContent, description: "Post deleted successfully.")]
  [SwaggerResponse(StatusCodes.Status404NotFound, description: "Post not found.")]
  [SwaggerResponse(StatusCodes.Status500InternalServerError, description: "Internal server error.")]
  public async Task<IActionResult> DeletePostById([FromRoute] Guid id, CancellationToken ct)
  {
    await _postService.DeleteByIdAsync(id, ct);

    return NoContent();
  }
}
