using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog4uSlf.Web.Dtos.Posts;

/// <summary>
/// Data Transfer Object for creating a new blog post.
/// </summary>
/// <param name="Title">The title of the blog post.</param>
/// <param name="Content">The main content of the blog post.</param>
/// <param name="Slug">A URL-friendly identifier for the blog post.</param>
public readonly record struct PostCreateDto([property: Required, JsonRequired] string Title,
  [property: Required, JsonRequired] string Content,
  string Slug);
