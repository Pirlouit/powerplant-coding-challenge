using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.ProductionPlan;

internal class Windturbine : ComputablePowerplant
{
    public Windturbine(Powerplant powerplant, Fuels fuels) : base(powerplant, fuels)
    {
    }

    public override double MaxPower => Math.Round(((double)_fuels.WindPercentage / 100) * _powerplant.Pmax, 1, MidpointRounding.ToPositiveInfinity);

    public override double AveragePriceByKwh => 0;
}
