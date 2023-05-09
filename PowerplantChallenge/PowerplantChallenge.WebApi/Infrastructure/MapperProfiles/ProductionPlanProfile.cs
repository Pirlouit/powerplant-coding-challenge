namespace PowerplantChallenge.WebApi.Infrastructure.MapperProfiles;

using AutoMapper;

using Models = PowerplantChallenge.WebApi.Models;
using Core = PowerplantChallenge.Core.Models;

public class ProductionPlanProfile : Profile
{
    public ProductionPlanProfile()
    {
        CreateMap<Models.Powerplant, Core.Powerplant>();
        CreateMap<Models.Fuels, Core.Fuels>()
            .ForCtorParam("WindPercentage", opt =>
                opt.MapFrom(f => f.Wind)
            );

        CreateMap<Core.PowerplantResult, Models.PowerplantResult>();
    }
}