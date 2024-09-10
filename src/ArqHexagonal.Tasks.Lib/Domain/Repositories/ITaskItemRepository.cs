﻿using ArqHexagonal.Tasks.Lib.Domain.Models;

namespace ArqHexagonal.Tasks.Lib.Domain.Repositories;

public interface ITaskItemRepository
{
    Task<TaskItem> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<TaskItem>> ListAsync(CancellationToken ct);
    Task<TaskItem> AddAsync(TaskItem taskItem, CancellationToken ct);
    Task UpdateAsync(TaskItem taskItem, CancellationToken ct);
    Task DeleteAsync(TaskItem TastaskItemkItem, CancellationToken ct);
}