namespace PowerplantChallenge.Core.Models;

public record Powerplant(
    string Name,
    string Type,
    double Efficiency,
    int Pmin,
    int Pmax
);
