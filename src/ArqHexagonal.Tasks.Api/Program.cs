using ArqHexagonal.Tasks.Api.Endpoints;
using ArqHexagonal.Tasks.Lib.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTasksServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/tasks")
   .MapTasksEnpoints()
   .WithTags("Tasks")
   .WithOpenApi()
   .WithMetadata();

app.Run();
