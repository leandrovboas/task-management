using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Net.Mime;

namespace TaskManagement.API.Configurations;

public static class HealthChecksAppBuilder
{
    //public static void UseCustomHealthChecks(this IApplicationBuilder app) =>
    //    app.UseHealthChecks("/health",
    //    new HealthCheckOptions()
    //    {
    //        ResponseWriter = async (context, report) =>
    //        {
    //            var result = JsonContent.SerializeObject(new
    //            {
    //                statusApplication = report.Status.ToString(),
    //                healthChecks = report.Entries.Select(e => new
    //                {
    //                    check = e.Key,
    //                    ErrorMessage = e.Value.Exception?.Message,
    //                    status = System.Enum.GetName(typeof(HealthStatus), e.Value.Status)
    //                })
    //            });
    //            context.Response.ContentType = MediaTypeNames.Application.Json;
    //            await context.Response.WriteAsync(result);
    //        },
    //    });
}
