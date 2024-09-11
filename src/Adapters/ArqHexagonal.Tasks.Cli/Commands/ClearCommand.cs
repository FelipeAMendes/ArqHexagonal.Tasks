using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class ClearCommand : Command<ClearCommand.Settings>
{
    public class Settings : CommandSettings { }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.Clear();
        return 0;
    }
}