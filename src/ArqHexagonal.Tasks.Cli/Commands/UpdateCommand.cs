using ArqHexagonal.Tasks.Lib.Application.Dtos;
using ArqHexagonal.Tasks.Lib.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class UpdateCommand : Command<UpdateCommand.Settings>
{
    private readonly ITaskItemService _service;

    public UpdateCommand(ITaskItemService service)
    {
        _service = service;
    }

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<id>")]
        public int Id { get; set; }

        [CommandArgument(1, "<title>")]
        public string Title { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var taskResult = _service.UpdateAsync(new TaskItemDto { Id = settings.Id, Title = settings.Title }, CancellationToken.None).GetAwaiter().GetResult();

        if (taskResult.Succeeded)
            AnsiConsole.MarkupLine("[bold green]Task updated.[/]");
        else
            AnsiConsole.MarkupLine("[bold red]Task not updated.[/]");

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (settings.Id <= 0)
            return ValidationResult.Error("Id is required");

        if (string.IsNullOrEmpty(settings.Title))
            return ValidationResult.Error("Title is required");

        if (settings.Title.Length < 3 || settings.Title.Length > 100)
            return ValidationResult.Error("Title must have between 3 and 100 characters");

        return base.Validate(context, settings);
    }
}