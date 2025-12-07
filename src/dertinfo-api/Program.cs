using AutoMapper;
using Azure.Identity;
using DertInfo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure application settings - explicitly add user secrets
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Load Azure App Configuration in non-development environments
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}
else
{
    var appConfigurationUri = Environment.GetEnvironmentVariable("AZURE_APP_CONFIG");

    if (!string.IsNullOrWhiteSpace(appConfigurationUri))
    {
        var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeSharedTokenCacheCredential = true
        });

        builder.Configuration.AddAzureAppConfiguration(options =>
        {
            options.Connect(new Uri(appConfigurationUri), credential)
                .Select(KeyFilter.Any, builder.Environment.EnvironmentName)
                .ConfigureKeyVault(kv =>
                {
                    kv.SetCredential(credential);
                });
        });
    }
}

// Configure Services
var mapperConfiguration = DertInfo.Api.Start.AutoMapperConfiguration.Build(builder);
DertInfo.Api.Start.EntityFramework.Build(builder);
DertInfo.Api.Start.CorsConfiguration.Build(builder);

// Add Controllers with Newtonsoft.Json support
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
    });

// Apply Configurations
DertInfo.Api.Start.Authorisations.Apply(builder.Services, builder.Configuration);
DertInfo.Api.Start.DependencyInjections.Apply(builder.Services, builder.Configuration);
DertInfo.Api.Start.ConfigureSwagger.Apply(builder.Services, builder.Configuration);
DertInfo.Api.Start.DependencyInjections.Apply(builder.Services, builder.Configuration);

// Add AutoMapper
builder.Services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());

// Add Application Insights
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DertInfo API v1");
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Run database migrations and seed data on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DertInfoContext>();
    try
    {
        context.Database.Migrate();
        context.EnsureSeedData();
    }
    catch (Exception ex)
    {
        System.Diagnostics.Trace.TraceError($"Database migration error: {ex.Message}");
    }
}

app.Run();
