using ArqHexagonal.Tasks.Core.Application.Dtos;
using ArqHexagonal.Tasks.Core.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class AddCommand : Command<AddCommand.Settings>
{
    private readonly ITaskItemService _service;

    public AddCommand(ITaskItemService service)
    {
        _service = service;
    }

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<title>")]
        public string Title { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var taskResult = _service.AddAsync(new TaskItemDto { Title = settings.Title }, CancellationToken.None).GetAwaiter().GetResult();

        if (taskResult.Succeeded)
            AnsiConsole.MarkupLine("[bold green]Task added.[/]");
        else
            AnsiConsole.MarkupLine("[bold red]Task not added.[/]");

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (string.IsNullOrEmpty(settings.Title))
            return ValidationResult.Error("Title is required");

        if (settings.Title.Length < 3 || settings.Title.Length > 100)
            return ValidationResult.Error("Title must have between 3 and 100 characters");

        return base.Validate(context, settings);
    }
}
