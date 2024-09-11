using ArqHexagonal.Tasks.Core.Application.Dtos;
using ArqHexagonal.Tasks.Core.Application.Utilities;

namespace ArqHexagonal.Tasks.Core.Application.UseCases;

public interface ITaskItemService
{
    Task<IEnumerable<TaskItemDto>> ListAsync(CancellationToken ct);
    Task<Results<TaskItemDto>> GetByIdAsync(int id, CancellationToken ct);
    Task<Results<TaskItemDto>> AddAsync(TaskItemDto taskItemDto, CancellationToken ct);
    Task<Results<TaskItemDto>> UpdateAsync(TaskItemDto taskItemDto, CancellationToken ct);
    Task<Results<TaskItemDto>> CompleteAsync(int id, CancellationToken ct);
    Task<Results<TaskItemDto>> DeleteAsync(int id, CancellationToken ct);
}
