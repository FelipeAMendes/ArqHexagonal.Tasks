using Spectre.Console;
using static ArqHexagonal.Tasks.Cli.DI.CliExtensions;
using static ArqHexagonal.Tasks.Cli.Extensions.ConsoleExtensions;

var app = ConfigureApp();

while (true)
{
    var input = AnsiConsole.Ask<string>("Type a command (getById|list|add|update|delete|complete) (or [bold red]exit[/]):");

    if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
        break;

    var commandArgs = ParseArguments(input);
    if (commandArgs.Length == 0)
    {
        AnsiConsole.MarkupLine("[bold red]Invalid command.[/]");
        return 0;
    }

    try
    {
        var exitCode = await app.RunAsync(commandArgs);
        if (exitCode != 0)
        {
            AnsiConsole.MarkupLine("[bold red]Error executing command.[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[bold red]Error: {ex.Message}[/]");
    }

    AnsiConsole.WriteLine();
}

AnsiConsole.MarkupLine("[bold green]Bye.[/]");
return 0;