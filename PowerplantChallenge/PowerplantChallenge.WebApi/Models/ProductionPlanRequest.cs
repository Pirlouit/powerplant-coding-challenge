using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerplantChallenge.WebApi.Models;

public class ProductionPlanRequest
{
    [JsonPropertyName("load"), Required]
    public int? Load { get; init; }

    [JsonPropertyName("fuels"), Required]
    public Fuels Fuels { get; init; } = null!;

    [JsonPropertyName("powerplants"), Required]
    public IReadOnlyCollection<Powerplant> Powerplants { get; init; } = null!;
}
