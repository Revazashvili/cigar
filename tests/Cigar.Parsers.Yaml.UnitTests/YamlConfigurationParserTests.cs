﻿using Xunit;
using YamlDotNet.Core;

namespace Cigar.Parsers.Yaml.UnitTests;

public class YamlConfigurationParserTests
{
    [Fact]
    public async Task Reads_Valid_Yaml_File()
    {
        var configurationParser = new YamlConfigurationParser();
        var configuration = await configurationParser.ParseAsync("valid.yaml");
        Assert.NotNull(configuration);
        Assert.NotNull(configuration.Execution);
        Assert.NotEmpty(configuration.Execution.Steps);

        Assert.Equal("http://localhost:8080", configuration.BaseUrl);
    }
    
    [Fact]
    public async Task Throws_Exception_On_Invalid_Yaml_File()
    {
        var configurationParser = new YamlConfigurationParser();
        await Assert.ThrowsAnyAsync<Exception>(async () => await configurationParser.ParseAsync("invalid.yaml"));
    }
}