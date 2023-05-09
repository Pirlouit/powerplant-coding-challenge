using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.ProductionPlan;

internal class Gasfired : ComputablePowerplant
{
    public Gasfired(Powerplant powerplant, Fuels fuels) : base(powerplant, fuels)
    {
    }

    public override double MaxPower => _powerplant.Pmax;

    public override double AveragePriceByKwh => _fuels.GasEuroMWh / _powerplant.Efficiency + 0.3 * _fuels.Co2EuroTon;
}
