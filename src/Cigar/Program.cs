// See https://aka.ms/new-console-template for more information

using Cigar.Creators;
using Cigar.Models;
using Cigar.Parsers;
using NBomber.CSharp;

if (!args.Any())
{
    const string logo = @"      _                  
  ___(_) __ _  __ _ _ __ 
 / __| |/ _` |/ _` | '__|
| (__| | (_| | (_| | |   
 \___|_|\__, |\__,_|_|   
        |___/            
";
    Console.WriteLine(logo);
    return;
}

var filePath = Environment.GetCommandLineArgs()[1];
if (!File.Exists(filePath))
{
    Console.WriteLine($"Can't find file on path: {filePath}");
    return;
}

Console.WriteLine(Path.GetExtension(filePath));
if (Path.GetExtension(filePath) != ".yaml")
{
    Console.WriteLine("please provide yaml file");
    return;
}

var parser = new YamlConfigurationParser();
Configuration? configuration = null;
try
{
    configuration = await parser.ParseAsync(filePath);
}
catch (Exception)
{
    Console.WriteLine("Can't parse yaml file");
}

if (configuration is not null)
{
    var context = NBomberContextCreator.Create(Path.GetFileName(filePath), configuration);
    context.Run();
}