using Cigar.Models;

namespace Cigar.Parsers;

public interface IConfigurationParser
{
    Task<Configuration> ParseAsync(string path);
}