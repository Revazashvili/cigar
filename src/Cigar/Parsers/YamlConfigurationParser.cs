using Cigar.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Cigar.Parsers;

public class YamlConfigurationParser : IConfigurationParser
{
    private readonly IDeserializer _deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();

    public async Task<Configuration> ParseAsync(string path) =>
        _deserializer.Deserialize<Configuration>(await File.ReadAllTextAsync(path));
}