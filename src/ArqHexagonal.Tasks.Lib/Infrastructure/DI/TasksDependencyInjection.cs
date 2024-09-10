using ArqHexagonal.Tasks.Lib.Application.UseCases;
using ArqHexagonal.Tasks.Lib.Data;
using ArqHexagonal.Tasks.Lib.Domain.Repositories;
using ArqHexagonal.Tasks.Lib.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArqHexagonal.Tasks.Lib.Infrastructure.DI;

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
