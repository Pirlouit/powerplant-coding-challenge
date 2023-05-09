using PowerplantChallenge.Core.Exceptions;
using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.ProductionPlan;

internal class ComputablePowerplantFactory
{
    public static ComputablePowerplant Create(Powerplant powerplant, Fuels fuels)
    {
        if (powerplant is null) throw new ArgumentNullException(nameof(powerplant));
        if (fuels is null) throw new ArgumentNullException(nameof(fuels));

        return powerplant.Type switch
        {
            "gasfired" => new Gasfired(powerplant, fuels),
            "turbojet" => new Turbojet(powerplant, fuels),
            "windturbine" => new Windturbine(powerplant, fuels),
            _ => throw new UnknownPowerplantTypeException(powerplant.Type),
        };
    }

    public static IEnumerable<ComputablePowerplant> CreateMany(IEnumerable<Powerplant> powerplants, Fuels fuels)
    {
        if (powerplants is null) throw new ArgumentNullException(nameof(powerplants));
        if (fuels is null) throw new ArgumentNullException(nameof(fuels));

        foreach (Powerplant powerplant in powerplants)
        {
            yield return Create(powerplant, fuels);
        }
    }
}
