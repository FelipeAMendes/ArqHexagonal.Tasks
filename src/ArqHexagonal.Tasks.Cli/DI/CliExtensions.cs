using ArqHexagonal.Tasks.Cli.Commands;
using ArqHexagonal.Tasks.Lib.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ArqHexagonal.Tasks.Cli.DI;

public static class CliExtensions
{
    public static CommandApp ConfigureApp()
    {
        var registrations = new ServiceCollection();
        registrations.AddTasksServices();
        var registrar = new TypeRegistrar(registrations);

        var app = new CommandApp(registrar);

        app.Configure(config =>
        {
            config.AddCommand<AddCommand>("add")
                  .WithAlias("a")
                  .WithDescription("add task")
                  .WithExample("New Task");

            config.AddCommand<UpdateCommand>("update")
                  .WithAlias("u")
                  .WithDescription("update task")
                  .WithExample("1", "Updated Task");

            config.AddCommand<DeleteCommand>("delete")
                  .WithAlias("d")
                  .WithDescription("delete task")
                  .WithExample("1");

            config.AddCommand<CompleteCommand>("complete")
                  .WithAlias("c")
                  .WithDescription("complete task")
                  .WithExample("1");

            config.AddCommand<GetByIdCommand>("getById")
                  .WithAlias("g")
                  .WithDescription("get task by id")
                  .WithExample("1");

            config.AddCommand<ListCommand>("list")
                  .WithAlias("l")
                  .WithDescription("list tasks")
                  .WithExample();

            config.AddCommand<ClearCommand>("clear")
                  .WithAlias("cls")
                  .WithDescription("clear console")
                  .WithExample();
        });

        return app;
    }
}
