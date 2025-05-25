using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Middleware;
using SecureTaskAPI.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Logger Configuration

Log.Logger = new LoggerConfiguration().WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IGetAPI , GetApi>();
builder.Services.AddScoped<IAddAPI , AddApi>();
builder.Services.AddScoped<IGetAllApis , GetAllApis>();
builder.Services.AddScoped<IDeleteApi, DeleteApi>();
builder.Services.AddScoped<IUpdateApi , UpdateApi>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomHeaderMiddleWare>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
