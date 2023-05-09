using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerplantChallenge.WebApi.Models;

public class Powerplant
{
    [JsonPropertyName("name"), Required]
    public string Name { get; init; } = null!;

    [JsonPropertyName("type"), Required]
    public string Type { get; init; } = null!;

    [JsonPropertyName("efficiency"), Required]
    public double? Efficiency { get; init; }

    [JsonPropertyName("pmin"), Required]
    public int? Pmin { get; init; }

    [JsonPropertyName("pmax"), Required]
    public int? Pmax { get; init; }
}
