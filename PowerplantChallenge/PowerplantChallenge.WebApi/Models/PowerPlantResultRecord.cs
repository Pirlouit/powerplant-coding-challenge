using System.Text.Json.Serialization;

namespace PowerplantChallenge.WebApi.Models;
public record PowerplantResult(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("p")] double Production
);
