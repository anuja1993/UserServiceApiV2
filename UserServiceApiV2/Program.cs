using Microsoft.EntityFrameworkCore;
using UserServiceApiV2.Data;

var builder = WebApplication.CreateBuilder(args);
var allowOrigns = "-allowOrigings";

// Add services to the container.

builder.Services.AddControllers();

// Add database context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors to allow any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigns, builder =>
    {
        builder.AllowAnyOrigin();
    });
});

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
