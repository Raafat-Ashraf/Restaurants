using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Domain.Exceptions;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
