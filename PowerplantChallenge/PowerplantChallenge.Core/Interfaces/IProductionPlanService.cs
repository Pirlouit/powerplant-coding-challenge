using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.Interfaces;

public interface IProductionPlanService
{
    public IReadOnlyCollection<PowerplantResult> Compute(int load, Fuels fuels, IReadOnlyCollection<Powerplant> powerplants);
}
