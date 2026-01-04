namespace Blog4uSlf.Domain.Interfaces.Common;

/// <summary>
/// Defines pagination parameters for data retrieval operations.
/// </summary>
/// <remarks>
/// This interface provides basic pagination functionality by specifying how many items to skip and take.
/// </remarks>
/// <example>
/// Usage example:
/// <code>
/// var params = new PaginateParams { Skip = 0, Take = 10 }; // Gets first 10 items
/// </code>
/// </example>
public interface IPaginateParams
{
  int Skip { get; set; }
  int Take { get; set; }
}
