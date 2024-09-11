namespace ArqHexagonal.Tasks.Core.Application.Dtos;

public record TaskItemDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public bool IsCompleted { get; init; }
}