using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
