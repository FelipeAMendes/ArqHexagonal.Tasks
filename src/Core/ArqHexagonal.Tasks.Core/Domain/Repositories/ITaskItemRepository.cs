using ArqHexagonal.Tasks.Core.Domain.Models;

namespace ArqHexagonal.Tasks.Core.Domain.Repositories;

public interface ITaskItemRepository
{
    Task<TaskItem> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<TaskItem>> ListAsync(CancellationToken ct);
    Task<TaskItem> AddAsync(TaskItem taskItem, CancellationToken ct);
    Task UpdateAsync(TaskItem taskItem, CancellationToken ct);
    Task DeleteAsync(TaskItem TastaskItemkItem, CancellationToken ct);
}