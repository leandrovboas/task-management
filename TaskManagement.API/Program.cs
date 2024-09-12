using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Net.Mime;
using TaskManagement.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseHealthChecks("/health");
app.UseHealthChecks("/health-json",
    new HealthCheckOptions()
    {
        ResponseWriter = async (context, report) =>
        {
            var result = JsonSerializer.Serialize(
                            new
               {
                   currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   statusApplication = report.Status.ToString(),
               });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(result);
        }
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
