namespace PowerplantChallenge.WebApi.Infrastructure;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using PowerplantChallenge.Core;
using PowerplantChallenge.Core.Interfaces;
using PowerplantChallenge.WebApi.Infrastructure.MapperProfiles;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductionPlanService, ProductionPlanService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductionPlanProfile>();
        });

#if DEBUG
        configuration.AssertConfigurationIsValid();
#endif
        services.AddSingleton(_ => configuration.CreateMapper());

        return services;
    }
}
