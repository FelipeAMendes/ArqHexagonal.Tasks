using ArqHexagonal.Tasks.Core.Domain.Models;
using ArqHexagonal.Tasks.Core.Domain.Repositories;
using ArqHexagonal.Tasks.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ArqHexagonal.Tasks.Persistence.Repositories;

public class TaskItemRepository(ApplicationDbContext context) : ITaskItemRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<TaskItem> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Set<TaskItem>().FindAsync([id], cancellationToken: ct);
    }

    public async Task<IEnumerable<TaskItem>> ListAsync(CancellationToken ct)
    {
        return await _context.Set<TaskItem>().ToListAsync(ct);
    }

    public async Task<TaskItem> AddAsync(TaskItem taskItem, CancellationToken ct)
    {
        await _context.Set<TaskItem>().AddAsync(taskItem);
        await _context.SaveChangesAsync(ct);
        return taskItem;
    }

    public async Task UpdateAsync(TaskItem taskItem, CancellationToken ct)
    {
        _context.Set<TaskItem>().Update(taskItem);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(TaskItem taskItem, CancellationToken ct)
    {
        _context.Set<TaskItem>().Remove(taskItem);
        await _context.SaveChangesAsync(ct);
    }
}
