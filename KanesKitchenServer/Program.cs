using Microsoft.EntityFrameworkCore;
using KanesKitchenServer.Data;
using KanesKitchenServer.Repositories;
using KanesKitchenServer.Interfaces;
using KanesKitchenServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserManagment, UserManagmentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.Configure<JwtSelection>(builder.Configuration.GetSection("JwtSelection"));

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
