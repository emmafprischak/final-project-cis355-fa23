using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using UserApi.Authorization;
using UserApi.Extensions;
using UserApi.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using UserApi.Entities;
using UserApi.Repositories;
using UserApi.Helpers;
using UserApi.DatabaseConfiguration;
using UserApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "User API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.ConfigureDatabase();
builder.ConfigureJwt();

// Configure logging
builder.Logging
    .ClearProviders()
    .AddConsole()
    .AddDebug();

var app = builder.Build();

// Add a user to the database during the startup process only when running locally
if (app.Environment.IsDevelopment())
{
    await UserDbSeeder.SeedUserAsync(app.Services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(next => context =>
{
    string path = context.Request.Path.Value;
    if (string.Equals(path, "/api/login", StringComparison.OrdinalIgnoreCase))
    {
        var tokens = context.RequestServices.GetRequiredService<IAntiforgery>().GetAndStoreTokens(context);
        context.Response.Cookies.Append("X-CSRF-TOKEN", tokens.RequestToken, new CookieOptions { HttpOnly = false });
    }
    return next(context);
});

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<ActivityLoggingMiddleware>();

app.Use(next => context =>
{
    if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put || context.Request.Method == HttpMethods.Delete)
    {
        context.RequestServices.GetRequiredService<IAntiforgery>().ValidateRequestAsync(context);
    }
    return next(context);
});

app.UseAuthorization();
app.MapControllers();
app.Run();
