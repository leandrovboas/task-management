var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
       options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

// Repositories
services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<ITaskRepository, TaskRepository>();

// Use Cases
services.AddScoped<CreateProjectUseCase>();
services.AddScoped<AddTaskUseCase>();
services.AddScoped<UpdateTaskUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
