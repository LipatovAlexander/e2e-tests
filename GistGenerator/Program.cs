using CommandLine;
using GistGenerator;

var generator = new Generator();

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options => generator.Generate(options));