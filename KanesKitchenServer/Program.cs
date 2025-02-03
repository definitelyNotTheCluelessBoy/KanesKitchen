using Microsoft.EntityFrameworkCore;
using KanesKitchenServer.Data;
using KanesKitchenServer.Repositories;
using KanesKitchenServer.Interfaces;
using KanesKitchenServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


builder.Services.Configure<JwtSelection>(builder.Configuration.GetSection("JwtSection"));
var jwtSelection = builder.Configuration.GetSection(nameof(JwtSelection)).Get<JwtSelection>();

builder.Services.AddAuthentication(options =>
{
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSelection!.Issuer,
        ValidAudience = jwtSelection.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSelection.Key))
    };
});

builder.Services.AddCors( options =>
{
options.AddPolicy("AllowBlazorClientAcces",
    builder => builder
    .WithOrigins("https://localhost:7048")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowBlazorClientAcces");

app.Run();
