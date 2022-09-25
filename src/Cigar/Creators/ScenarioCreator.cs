using Cigar.Models;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

namespace Cigar.Creators;

public static class ScenarioCreator
{
    public static Scenario Create(string fileName, Configuration configuration)
    {
        var httpFactory = HttpClientFactory.Create();
        var steps = configuration.Execution.Steps.Select(s => StepCreator.Create(httpFactory, s, configuration.BaseUrl))
            .ToArray();
        return ScenarioBuilder
            .CreateScenario(fileName, steps)
            .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(30)));
    }
}