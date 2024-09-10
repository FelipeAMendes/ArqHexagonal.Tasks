using ArqHexagonal.Tasks.Lib.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class CompleteCommand : Command<CompleteCommand.Settings>
{
    private readonly ITaskItemService _service;

    public CompleteCommand(ITaskItemService service)
    {
        _service = service;
    }

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<id>")]
        public int Id { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var taskResult = _service.CompleteAsync(settings.Id, CancellationToken.None).GetAwaiter().GetResult();

        if (taskResult.Succeeded)
            AnsiConsole.MarkupLine("[bold green]Task completed.[/]");
        else
            AnsiConsole.MarkupLine("[bold red]Task not completed.[/]");

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (settings.Id <= 0)
            return ValidationResult.Error("Id is required");

        return base.Validate(context, settings);
    }
}
