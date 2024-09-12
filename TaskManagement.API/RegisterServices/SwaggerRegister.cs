using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TaskManagement.API.RegisterServices;

public static class SwaggerRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Task Management",
                Description = "Gerenciador de projetos e tarefaz",
                Version = "v1"
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
