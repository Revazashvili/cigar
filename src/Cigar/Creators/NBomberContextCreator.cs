using Cigar.Models;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Network.Ping;

namespace Cigar.Creators;

public static class NBomberContextCreator
{
    public static NBomberContext Create(string fileName, Configuration configuration)
    {
        return NBomberRunner
            .RegisterScenarios(ScenarioCreator.Create(fileName, configuration))
            .WithWorkerPlugins(new PingPlugin(PingPluginConfig.CreateDefault(configuration.BaseUrl)))
            .WithTestName(fileName);
    }
}