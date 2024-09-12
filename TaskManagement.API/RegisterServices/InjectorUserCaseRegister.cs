using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.Interfaces;

namespace TaskManagement.API.RegisterServices;

public class InjectorUserCaseRegister
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICreateProjectUseCase, CreateProjectUseCase>();
        services.AddScoped<IAddWorkItemsUseCase, AddWorkItemsUseCase>();
        services.AddScoped<IUpdateWorkItemsUseCase, UpdateWorkItemsUseCase>();
        services.AddScoped<IListProjetcsUseCase, ListProjectsUseCase>();
        services.AddScoped<IListWorkItemsUseCase, ListWorkItemsUseCase>();
        services.AddScoped<IDeleteWorkItemUseCase, DeleteWorkItemUseCase>();
        services.AddScoped<IAddCommentUseCase, AddCommentUseCase>();
    }
}
