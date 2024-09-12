using TaskManagement.API.RegisterServices;

namespace TaskManagement.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            InjectorDbContentRegister.RegisterServices(services, Configuration);
            SwaggerRegister.RegisterServices(services);
            InjectorUserCaseRegister.RegisterServices(services);
            InjectorRepositoriesRegister.RegisterServices(services);
        }
    }
}
