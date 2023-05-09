namespace PowerplantChallenge.Core.Models;

public record Fuels(
    double GasEuroMWh,
    double KerosineEuroMWh,
    int Co2EuroTon,
    int WindPercentage
);
