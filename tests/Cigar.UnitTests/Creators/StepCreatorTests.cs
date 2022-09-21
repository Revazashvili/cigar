using Cigar.Creators;
using Cigar.Models;
using NBomber.Plugins.Http.CSharp;

namespace Cigar.UnitTests.Creators;

public class StepCreatorTests
{
    [Fact]
    public void Should_Create_Scenario_Test()
    {
        var httpFactory = HttpClientFactory.Create();
        var step = new Step("test", new Request
        {
            Url = "/customers",
            Method = RequestMethod.Get,
            Headers = new RequestHeaders()
        }, "test");
        var baseUrl = "http://localhost:80";
        var scenarioStep = StepCreator.Create(httpFactory,step,baseUrl);
        Assert.NotNull(scenarioStep);
        Assert.Equal("test",scenarioStep.StepName);
    }
}