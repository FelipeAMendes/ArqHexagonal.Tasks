using ArqHexagonal.Tasks.Lib.Application.Dtos;
using ArqHexagonal.Tasks.Lib.Application.UseCases;

namespace ArqHexagonal.Tasks.Api.Endpoints;

public static class TaskItemEndpoints
{
    public static RouteGroupBuilder MapTasksEnpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/tasks/{id}", GetTaskByIdAsync)
             .WithName("GetTaskById")
             .Produces<TaskItemDto>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/tasks", ListTasksAsync)
             .WithName("ListTasks")
             .Produces<List<TaskItemDto>>(StatusCodes.Status200OK);

        group.MapPost("/tasks", AddAsync)
             .WithName("AddTask")
             .Accepts<TaskItemDto>("application/json")
             .Produces(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status400BadRequest);

        group.MapPut("/tasks", UpdateAsync)
             .WithName("UpdateTask")
             .Accepts<TaskItemDto>("application/json")
             .Produces(StatusCodes.Status204NoContent)
             .Produces(StatusCodes.Status400BadRequest);

        group.MapPatch("/tasks/{id}/complete", CompleteAsync)
             .WithName("CompleteTask")
             .Produces(StatusCodes.Status204NoContent)
             .Produces(StatusCodes.Status400BadRequest);

        group.MapDelete("/tasks/{id}", DeleteAsync)
             .WithName("DeleteTask")
             .Produces(StatusCodes.Status204NoContent)
             .Produces(StatusCodes.Status400BadRequest);

        return group;
    }

    internal static async Task<IResult> GetTaskByIdAsync(ITaskItemService taskItemService, int id, CancellationToken ct)
    {
        var taskResult = await taskItemService.GetByIdAsync(id, ct);
        if (taskResult.Succeeded)
            return Results.Ok(taskResult.Result);

        return Results.NotFound();
    }

    internal static async Task<IResult> ListTasksAsync(ITaskItemService taskItemService, CancellationToken ct)
    {
        var tasks = await taskItemService.ListAsync(ct);
        return Results.Ok(tasks);
    }

    internal static async Task<IResult> AddAsync(ITaskItemService taskItemService, TaskItemDto taskItemDto, CancellationToken ct)
    {
        var taskResult = await taskItemService.AddAsync(taskItemDto, ct);
        if (taskResult.Succeeded)
            return Results.Created($"/tasks/{taskResult.Result.Id}", taskResult.Result);

        return Results.BadRequest(taskResult.Message);
    }

    internal static async Task<IResult> UpdateAsync(ITaskItemService taskItemService, TaskItemDto taskItemDto, CancellationToken ct)
    {
        var taskResult = await taskItemService.UpdateAsync(taskItemDto, ct);
        if (taskResult.Succeeded)
            return Results.NoContent();

        return Results.BadRequest(taskResult.Message);
    }

    internal static async Task<IResult> CompleteAsync(ITaskItemService taskItemService, int id, CancellationToken ct)
    {
        var taskResult = await taskItemService.CompleteAsync(id, ct);
        if (taskResult.Succeeded)
            return Results.NoContent();

        return Results.BadRequest(taskResult.Message);
    }

    internal static async Task<IResult> DeleteAsync(ITaskItemService taskItemService, int id, CancellationToken ct)
    {
        var taskResult = await taskItemService.DeleteAsync(id, ct);
        if (taskResult.Succeeded)
            return Results.NoContent();

        return Results.BadRequest(taskResult.Message);
    }
}
