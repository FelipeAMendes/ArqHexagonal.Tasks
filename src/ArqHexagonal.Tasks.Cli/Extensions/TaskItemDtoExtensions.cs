using ArqHexagonal.Tasks.Lib.Application.Dtos;

namespace ArqHexagonal.Tasks.Cli.Extensions;

public static class TaskItemDtoExtensions
{
    public static string GetIdColumn(this TaskItemDto taskItem)
    {
        return $"[bold]{taskItem.Id}[/]";
    }

    public static string GetTitleColumn(this TaskItemDto taskItem)
    {
        return $"[blue]{taskItem.Title}[/]";
    }

    public static string GetIsCompletedColumn(this TaskItemDto taskItem)
    {
        return taskItem.IsCompleted ? "[green]Yes[/]" : "[red]No[/]";
    }
}
