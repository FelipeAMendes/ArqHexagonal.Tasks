using ArqHexagonal.Tasks.Core.Application.UseCases;
using ArqHexagonal.Tasks.Core.Domain.Repositories;
using ArqHexagonal.Tasks.Persistence.Data;
using ArqHexagonal.Tasks.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArqHexagonal.Tasks.Persistence.DI;

public static class TasksDependencyInjection
{
    public static IServiceCollection AddTasksServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TasksDb"));
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<ITaskItemService, TaskItemService>();
        return services;
    }
}
