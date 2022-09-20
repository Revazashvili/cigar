using Cigar.Parsers.Kernel.Models;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

namespace Cigar.Core;

public static class ScenarioCreator
{
    public static void Create(Configuration configuration)
    {
        var httpFactory = HttpClientFactory.Create();
        var steps = configuration.Execution.Steps.Select(s => StepCreator.Create(httpFactory,s,configuration.BaseUrl)).ToArray();
        var scenario = ScenarioBuilder
            .CreateScenario("test", steps)//TODO: Name
            .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(30)));
    
        var pingPlugin = new PingPlugin(PingPluginConfig.CreateDefault(configuration.BaseUrl));
        NBomberRunner
            .RegisterScenarios(scenario)
            .WithWorkerPlugins(pingPlugin)
            .Run();
    }
}