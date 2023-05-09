using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.ProductionPlan;

internal abstract class ComputablePowerplant
{
    protected readonly Powerplant _powerplant;
    protected readonly Fuels _fuels;

    public ComputablePowerplant(Powerplant powerplant, Fuels fuels)
    {
        _powerplant = powerplant;
        _fuels = fuels;
    }

    public string Name => _powerplant.Name;
    public int Pmin => _powerplant.Pmin;
    public int Pmax => _powerplant.Pmax;

    public abstract double MaxPower { get; }

    public abstract double AveragePriceByKwh { get; }
}
