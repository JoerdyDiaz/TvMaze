using Api.FilterAuthorization;
using CapaServicios;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ApiExternaSettings>(builder.Configuration.GetSection("ApiExternaSettings"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<ITvMazePeopleService, TvMazePeopleService>();
builder.Services.AddScoped<ITvMazeShowService, TvMazeShowService>();

//// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tv Maze API", Version = "v1" });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key necesaria para acceder al endpoints. x-api-key: TvMaze*!$",
        In = ParameterLocation.Header,
        Name = "x-api-key",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Scheme = "ApiKeyScheme",
                Name = "x-api-key",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// Agrega servicios al contenedor.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseRouting();

// Configurar los endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tv Maze API V1");
    c.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }

