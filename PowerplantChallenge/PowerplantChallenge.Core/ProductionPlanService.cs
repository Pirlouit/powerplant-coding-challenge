using PowerplantChallenge.Core.Interfaces;
using PowerplantChallenge.Core.Models;
using PowerplantChallenge.Core.ProductionPlan;

namespace PowerplantChallenge.Core;

public class ProductionPlanService : IProductionPlanService
{
    public IReadOnlyCollection<PowerplantResult> Compute(int load, Fuels fuels, IReadOnlyCollection<Powerplant> powerplants)
    {
        if (powerplants is null) throw new ArgumentNullException(nameof(powerplants));
        if (fuels is null) throw new ArgumentNullException(nameof(fuels));

        var computablePowerPlants = ComputablePowerplantFactory.CreateMany(powerplants, fuels);
        var leftoverLoad = (double)load;
        var orderedComputablePowerPlants = computablePowerPlants
            .OrderBy(p => p.AveragePriceByKwh)
            .ThenByDescending(p => p.Pmin)
            .ToArray();

        return orderedComputablePowerPlants
            .Select((p, i) =>
            {
                double currentPowerLoad = 0;
                if (leftoverLoad >= p.Pmin)
                {
                    currentPowerLoad = Math.Min(p.MaxPower, leftoverLoad);
                    double tmpLeftoverLoad = leftoverLoad - currentPowerLoad;
                    if (tmpLeftoverLoad > 0 && i < orderedComputablePowerPlants.Length - 1)
                    {
                        var nextPowerplantPmin = orderedComputablePowerPlants[i + 1].Pmin;
                        if (tmpLeftoverLoad < nextPowerplantPmin)
                        {
                            currentPowerLoad -= nextPowerplantPmin - tmpLeftoverLoad;
                            if(currentPowerLoad < p.Pmin)
                            {
                                currentPowerLoad = p.Pmin;
                            }
                        }
                    }
                }
                leftoverLoad -= currentPowerLoad;
                return new PowerplantResult(p.Name, currentPowerLoad);
            }).ToList();
    }
}
