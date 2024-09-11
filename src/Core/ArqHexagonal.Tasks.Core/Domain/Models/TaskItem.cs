namespace ArqHexagonal.Tasks.Core.Domain.Models;

public class TaskItem(string title)
{
    public int Id { get; private set; }
    public string Title { get; private set; } = title;
    public bool IsCompleted { get; private set; } = false;

    public void Update(string title)
    {
        Title = title;
    }

    public void Complete()
    {
        IsCompleted = true;
    }
}