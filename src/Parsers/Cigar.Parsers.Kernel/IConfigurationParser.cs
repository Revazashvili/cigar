using Cigar.Parsers.Kernel.Models;

namespace Cigar.Parsers.Kernel;

public interface IConfigurationParser
{
    Task<Configuration> ParseAsync(string path);
}