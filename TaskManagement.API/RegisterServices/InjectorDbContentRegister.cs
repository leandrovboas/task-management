using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Configurations;

namespace TaskManagement.API.RegisterServices;

public static class InjectorDbContentRegister
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
