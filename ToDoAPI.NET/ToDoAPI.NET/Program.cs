using Microsoft.EntityFrameworkCore;
using ToDoAPI.NET.Context;
using ToDoAPI.NET.Interfaces;
using ToDoAPI.NET.Model.Repositories;
using ToDoAPI.NET.Validations.Interfaces;
using ToDoAPI.NET.Validations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(op =>
            op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IValidateStatusJobs, ValidateStatusJobs>();

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
