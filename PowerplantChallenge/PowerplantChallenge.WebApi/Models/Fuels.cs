using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerplantChallenge.WebApi.Models;

public class Fuels
{
    [JsonPropertyName("gas(euro/MWh)"), Required]
    public double? GasEuroMWh { get; init; }

    [JsonPropertyName("kerosine(euro/MWh)"), Required]
    public double? KerosineEuroMWh { get; init; }

    [JsonPropertyName("co2(euro/ton)"), Required]
    public int? Co2EuroTon { get; init; }

    [JsonPropertyName("wind(%)"), Required]
    public int? Wind { get; init; }
}
