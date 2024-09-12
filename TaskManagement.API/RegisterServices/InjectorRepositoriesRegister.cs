using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.API.RegisterServices;

public class InjectorRepositoriesRegister
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IWorkItemsRepository, WorkItemsRepository>();
        services.AddScoped<IWorkItemsHistoryRepository, WorkItemsHistoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
    }
}
