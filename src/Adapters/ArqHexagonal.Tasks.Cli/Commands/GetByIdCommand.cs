using ArqHexagonal.Tasks.Cli.Extensions;
using ArqHexagonal.Tasks.Core.Application.UseCases;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.Commands;

public class GetByIdCommand : Command<GetByIdCommand.Settings>
{
    private readonly ITaskItemService _service;

    public GetByIdCommand(ITaskItemService service)
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
        var taskResult = _service.GetByIdAsync(settings.Id, CancellationToken.None).GetAwaiter().GetResult();

        if (!taskResult.Succeeded)
        {
            AnsiConsole.MarkupLine("[bold red]Task not found.[/]");
            return 0;
        }

        var task = taskResult.Result;

        var grid = new Grid();

        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        grid.AddRow([
            new Text("Id", new Style(Color.Blue, Color.Black)).LeftJustified(),
            new Text("Title", new Style(Color.Blue, Color.Black)).LeftJustified(),
            new Text("Completed?", new Style(Color.Red, Color.Black)).Centered()
        ]);

        grid.AddRow([
            task.GetIdColumn(),
            task.GetTitleColumn(),
            task.GetIsCompletedColumn()
        ]);

        AnsiConsole.Write(grid);

        return 0;
    }
}
