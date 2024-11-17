using System.Text;
using System.Text.Json.Serialization;
using HikingInforamtionSystemCore.Interfaces;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Seeders;
using HikingInforamtionSystemCore.Services;
using HikingInformationSystem.Controllers;
using HikingInformationSystem.ExceptionHandling;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemInfrastructure.Data;
using HikingInformationSystemInfrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HikingInformationSystemDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHikeRepository, HikeRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IPointRepository, PointRepository>();

builder.Services.AddScoped<IHikeService, HikeService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IPointService, PointService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<AuthDbSeeder>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<HikingInformationSystemDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters.ValidAudience = builder.Configuration["JWT:ValidAudience"];
    options.TokenValidationParameters.ValidateAudience = true;
    options.TokenValidationParameters.ValidIssuer = builder.Configuration["JWT:ValidIssuer"];
    options.TokenValidationParameters.ValidateIssuer = true;
    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!));
    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
    options.TokenValidationParameters.ValidateLifetime = true;
    options.TokenValidationParameters.ValidAlgorithms = [SecurityAlgorithms.HmacSha256];
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saitynai", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        },
    });
});

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<HikingInformationSystemDataContext>();
dbContext.Database.Migrate();

var dbSeeder = scope.ServiceProvider.GetRequiredService<AuthDbSeeder>();
await dbSeeder.SeedAsync();

app.Run();