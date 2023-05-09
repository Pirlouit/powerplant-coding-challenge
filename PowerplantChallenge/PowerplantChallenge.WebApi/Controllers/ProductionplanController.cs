using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using PowerplantChallenge.Core.Interfaces;
using PowerplantChallenge.WebApi.Models;

namespace PowerplantChallenge.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductionplanController : ControllerBase
{
    private readonly ILogger<ProductionplanController> _logger;
    private readonly IMapper _mapper;
    private readonly IProductionPlanService _productionPlanService;

    public ProductionplanController(
        ILogger<ProductionplanController> logger,
        IMapper mapper,
        IProductionPlanService productionPlanService)
    {
        _logger = logger;
        _mapper = mapper;
        _productionPlanService = productionPlanService;
    }

    [HttpPost]
    public ProductionPlanResponse ComputeProductionPlan([FromBody] ProductionPlanRequest request)
    {
        var fuels = _mapper.Map<Core.Models.Fuels>(request.Fuels);
        var powerplants = _mapper.Map<Core.Models.Powerplant[]>(request.Powerplants);

        var result = _productionPlanService.Compute((int)request.Load!, fuels, powerplants);

        return _mapper.Map<ProductionPlanResponse>(result);
    }
}