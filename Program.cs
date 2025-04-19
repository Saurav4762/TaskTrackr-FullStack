using Microsoft.EntityFrameworkCore;
using TaskTrackr.Data;
using TaskTrackr.Repository;
using TaskTrackr.Repository.Interface;
using TaskTrackr.Services;
using TaskTrackr.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();



builder.Services.AddDbContext<EfCoreDbContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    b.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
