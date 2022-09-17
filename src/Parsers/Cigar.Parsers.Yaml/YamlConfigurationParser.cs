using Cigar.Parsers.Kernel;
using Cigar.Parsers.Kernel.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Cigar.Parsers.Yaml;

public class YamlConfigurationParser : IConfigurationParser
{
    private readonly IDeserializer _deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();

    public async Task<Configuration> ParseAsync(string path) =>
        _deserializer.Deserialize<Configuration>(await File.ReadAllTextAsync(path));
}