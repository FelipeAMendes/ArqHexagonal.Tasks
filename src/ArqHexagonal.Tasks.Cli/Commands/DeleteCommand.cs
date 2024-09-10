using ArqHexagonal.Tasks.Lib.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class DeleteCommand : Command<DeleteCommand.Settings>
{
    private readonly ITaskItemService _service;

    public DeleteCommand(ITaskItemService service)
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
        var taskResult = _service.DeleteAsync(settings.Id, CancellationToken.None).GetAwaiter().GetResult();

        if (taskResult.Succeeded)
            AnsiConsole.MarkupLine("[bold green]Task deleted.[/]");
        else
            AnsiConsole.MarkupLine("[bold red]Task not deleted.[/]");

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (settings.Id <= 0)
            return ValidationResult.Error("Id is required");

        return base.Validate(context, settings);
    }
}
