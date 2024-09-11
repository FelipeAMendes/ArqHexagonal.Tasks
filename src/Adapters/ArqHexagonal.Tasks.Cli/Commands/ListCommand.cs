using ArqHexagonal.Tasks.Cli.Extensions;
using ArqHexagonal.Tasks.Core.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class ListCommand : Command<ListCommand.Settings>
{
    private readonly ITaskItemService _service;

    public ListCommand(ITaskItemService service)
    {
        _service = service;
    }

    public class Settings : CommandSettings { }

    public override int Execute(CommandContext context, Settings settings)
    {
        var tasks = _service.ListAsync(CancellationToken.None).GetAwaiter().GetResult();

        if (!tasks.Any())
        {
            AnsiConsole.MarkupLine("[bold red]No tasks found.[/]");
            return 0;
        }

        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Title");
        table.AddColumn("Completed?");

        foreach (var task in tasks)
        {
            table.AddRow(task.GetIdColumn(), task.GetTitleColumn(), task.GetIsCompletedColumn());
        }

        AnsiConsole.Write(table);

        return 0;
    }
}
