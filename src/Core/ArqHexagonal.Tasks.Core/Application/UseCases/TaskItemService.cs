using ArqHexagonal.Tasks.Core.Application.Dtos;
using ArqHexagonal.Tasks.Core.Application.Utilities;
using ArqHexagonal.Tasks.Core.Domain.Models;
using ArqHexagonal.Tasks.Core.Domain.Repositories;

namespace ArqHexagonal.Tasks.Core.Application.UseCases;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _repository;

    public TaskItemService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItemDto>> ListAsync(CancellationToken ct)
    {
        var tasks = await _repository.ListAsync(ct);
        return tasks.Select(t => new TaskItemDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        });
    }

    public async Task<Results<TaskItemDto>> GetByIdAsync(int id, CancellationToken ct)
    {
        if (await _repository.GetByIdAsync(id, ct) is var taskitem && taskitem is null)
            return Results<TaskItemDto>.Failure("Task not found");

        var taskItemDto = new TaskItemDto
        {
            Id = taskitem.Id,
            Title = taskitem.Title,
            IsCompleted = taskitem.IsCompleted
        };

        return Results<TaskItemDto>.Success(taskItemDto);
    }

    public async Task<Results<TaskItemDto>> AddAsync(TaskItemDto taskItemDto, CancellationToken ct)
    {
        var taskItem = new TaskItem(taskItemDto.Title);

        taskItem = await _repository.AddAsync(taskItem, ct);

        return Results<TaskItemDto>.Success(new TaskItemDto { Id = taskItem.Id, Title = taskItem.Title });
    }

    public async Task<Results<TaskItemDto>> UpdateAsync(TaskItemDto taskItemDto, CancellationToken ct)
    {
        if (await _repository.GetByIdAsync(taskItemDto.Id, ct) is var taskItem && taskItem is null)
            return Results<TaskItemDto>.Failure("Task not found");

        taskItem.Update(taskItemDto.Title);

        await _repository.UpdateAsync(taskItem, ct);
        return Results<TaskItemDto>.Success();
    }

    public async Task<Results<TaskItemDto>> CompleteAsync(int id, CancellationToken ct)
    {
        if (await _repository.GetByIdAsync(id, ct) is var taskItem && taskItem is null)
            return Results<TaskItemDto>.Failure("Task not found");

        taskItem.Complete();

        await _repository.UpdateAsync(taskItem, ct);
        return Results<TaskItemDto>.Success();
    }

    public async Task<Results<TaskItemDto>> DeleteAsync(int id, CancellationToken ct)
    {
        if (await _repository.GetByIdAsync(id, ct) is var taskItem && taskItem is null)
            return Results<TaskItemDto>.Failure("Task not found");

        await _repository.DeleteAsync(taskItem, ct);
        return Results<TaskItemDto>.Success();
    }
}