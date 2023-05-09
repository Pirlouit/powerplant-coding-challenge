using Microsoft.AspNetCore.Mvc.Testing;

using PowerplantChallenge.WebApi.Models;

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PowerplantChallenge.WebApi.Tests;

public class ProductionPlanControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient appClient;

    public ProductionPlanControllerShould(WebApplicationFactory<Program> app)
    {
        appClient = app.CreateClient();
    }

    private async Task<HttpResponseMessage> ComputeProductionPlanAsync(ProductionPlanRequest productionPlanRequest)
    {
        var json = JsonSerializer.Serialize(productionPlanRequest);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        return await appClient.PostAsync("/productionplan", data);
    }

    [Fact]
    public async Task Return_ProductionPlanResponse_With_CorrectValues()
    {
        var request = new ProductionPlanRequest
        {
            Load = 480,
            Fuels = new()
            {
                GasEuroMWh = 13.4,
                KerosineEuroMWh = 50.8,
                Co2EuroTon = 20,
                Wind = 60
            },
            Powerplants = new Powerplant[]
            {
                new()
                {
                    Name = "gasfiredbig1",
                    Type = "gasfired",
                    Efficiency = 0.53,
                    Pmin = 100,
                    Pmax = 460
                },
                new()
                {
                    Name = "gasfiredbig2",
                    Type = "gasfired",
                    Efficiency = 0.53,
                    Pmin = 100,
                    Pmax = 460
                },
                new()
                {
                    Name = "gasfiredsomewhatsmaller",
                    Type = "gasfired",
                    Efficiency = 0.37,
                    Pmin = 40,
                    Pmax = 210
                },
                new()
                {
                    Name = "tj1",
                    Type = "turbojet",
                    Efficiency = 0.3,
                    Pmin = 0,
                    Pmax = 16
                },
                new()
                {
                    Name = "windpark1",
                    Type = "windturbine",
                    Efficiency = 1,
                    Pmin = 0,
                    Pmax = 150
                },
                new()
                {
                    Name = "windpark2",
                    Type = "windturbine",
                    Efficiency = 1,
                    Pmin = 0,
                    Pmax = 36
                }
            }
        };

        var httpReponse = await ComputeProductionPlanAsync(request);
        var result = await httpReponse.Content.ReadFromJsonAsync<ProductionPlanResponse>();

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
}