using PowerplantChallenge.Core.Interfaces;
using PowerplantChallenge.Core.Models;

namespace PowerplantChallenge.Core.Tests;

public class ProductionPlanServiceShould
{
    private readonly IProductionPlanService _productionPlanService;

    public ProductionPlanServiceShould()
    {
        _productionPlanService = new ProductionPlanService();
    }

    [Fact]
    public void Return_AnArrayOfPowerPlantResult_WithCorrectValues_When_Input_Is_Payload1()
    {
        var load = 480;
        var fuels = new Fuels(
            GasEuroMWh: 13.4,
            KerosineEuroMWh: 50.8,
            Co2EuroTon: 20,
            WindPercentage: 60
        );
        var powerplants = new Powerplant[]
        {
            new("gasfiredbig1", "gasfired", 0.53, 100, 460),
            new("gasfiredbig2", "gasfired", 0.53, 100, 460),
            new("gasfiredsomewhatsmaller", "gasfired", 0.37, 40, 210),
            new("tj1", "turbojet", 0.3, 0, 16),
            new("windpark1", "windturbine", 1, 0, 150),
            new("windpark2", "windturbine", 1, 0, 36)
        };

        var result = _productionPlanService.Compute(load, fuels, powerplants);

        Assert.Collection(result,
            r =>
            {
                Assert.Equal("windpark1", r.Name);
                Assert.Equal(90, r.Production);
            },
            r =>
            {
                Assert.Equal("windpark2", r.Name);
                Assert.Equal(21.6, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig1", r.Name);
                Assert.Equal(368.4, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig2", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredsomewhatsmaller", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("tj1", r.Name);
                Assert.Equal(0, r.Production);
            }
        );
    }

    [Fact]
    public void Return_AnArrayOfPowerPlantResult_WithCorrectValues_When_Input_Is_Payload2()
    {
        var load = 480;
        var fuels = new Fuels(
            GasEuroMWh: 13.4,
            KerosineEuroMWh: 50.8,
            Co2EuroTon: 20,
            WindPercentage: 0
        );
        var powerplants = new Powerplant[]
        {
            new("gasfiredbig1", "gasfired", 0.53, 100, 460),
            new("gasfiredbig2", "gasfired", 0.53, 100, 460),
            new("gasfiredsomewhatsmaller", "gasfired", 0.37, 40, 210),
            new("tj1", "turbojet", 0.3, 0, 16),
            new("windpark1", "windturbine", 1, 0, 150),
            new("windpark2", "windturbine", 1, 0, 36)
        };

        var result = _productionPlanService.Compute(load, fuels, powerplants);

        Assert.Collection(result,
            r =>
            {
                Assert.Equal("windpark1", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("windpark2", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig1", r.Name);
                Assert.Equal(380, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig2", r.Name);
                Assert.Equal(100, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredsomewhatsmaller", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("tj1", r.Name);
                Assert.Equal(0, r.Production);
            }
        );
    }

    [Fact]
    public void Return_AnArrayOfPowerPlantResult_WithCorrectValues_When_Input_Is_Payload3()
    {
        var load = 910;
        var fuels = new Fuels(
            GasEuroMWh: 13.4,
            KerosineEuroMWh: 50.8,
            Co2EuroTon: 20,
            WindPercentage: 60
        );
        var powerplants = new Powerplant[]
        {
            new("gasfiredbig1", "gasfired", 0.53, 100, 460),
            new("gasfiredbig2", "gasfired", 0.53, 100, 460),
            new("gasfiredsomewhatsmaller", "gasfired", 0.37, 40, 210),
            new("tj1", "turbojet", 0.3, 0, 16),
            new("windpark1", "windturbine", 1, 0, 150),
            new("windpark2", "windturbine", 1, 0, 36)
        };

        var result = _productionPlanService.Compute(load, fuels, powerplants);
        var douze = result.Sum(p => p.Production);
        Assert.Collection(result,
            r =>
            {
                Assert.Equal("windpark1", r.Name);
                Assert.Equal(90, r.Production);
            },
            r =>
            {
                Assert.Equal("windpark2", r.Name);
                Assert.Equal(21.6, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig1", r.Name);
                Assert.Equal(460, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredbig2", r.Name);
                Assert.Equal(338.4, r.Production);
            },
            r =>
            {
                Assert.Equal("gasfiredsomewhatsmaller", r.Name);
                Assert.Equal(0, r.Production);
            },
            r =>
            {
                Assert.Equal("tj1", r.Name);
                Assert.Equal(0, r.Production);
            }
        );
    }
}