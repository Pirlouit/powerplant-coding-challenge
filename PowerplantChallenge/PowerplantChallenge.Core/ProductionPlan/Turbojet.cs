using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.ProductionPlan;

internal class Turbojet : ComputablePowerplant
{
    public Turbojet(Powerplant powerplant, Fuels fuels) : base(powerplant, fuels)
    {
    }

    public override double MaxPower => _powerplant.Pmax;

    public override double AveragePriceByKwh => _fuels.KerosineEuroMWh / _powerplant.Efficiency;
}
