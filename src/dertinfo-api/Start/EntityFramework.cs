using DertInfo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DertInfo.Api.Start
{
    public static class EntityFramework
    {
        public static void Build(WebApplicationBuilder builder)
        {
            // Add services to the container
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DertInfoContext>(options =>
                {
                    try
                    {
                        var sqlServerName = builder.Configuration["SqlConnection:ServerName"];
                        var sqlServerAdminUsername = builder.Configuration["SqlConnection:ServerAdminName"];
                        var sqlServerAdminPassword = builder.Configuration["SqlConnection:ServerAdminPassword"];
                        var sqlServerDatabaseName = builder.Configuration["SqlConnection:DatabaseName"];

                        if (string.IsNullOrEmpty(sqlServerName) || string.IsNullOrEmpty(sqlServerDatabaseName))
                        {
                            System.Diagnostics.Trace.TraceError("SQL Connection configuration is missing");
                            var connectionString = "Server=.;Database=DertInfo;Integrated Security=true;";
                            options.UseSqlServer(connectionString);
                        }
                        else
                        {
                            string connectionString =
                                $"Server={sqlServerName};" +
                                $"Database={sqlServerDatabaseName};" +
                                $"User Id={sqlServerAdminUsername};" +
                                $"Password={sqlServerAdminPassword};" +
                                $"Persist Security Info=False;";

                            if (builder.Environment.IsDevelopment())
                            {
                                connectionString += "Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
                            }

                            options.UseSqlServer(connectionString);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError($"Database configuration error: {ex.Message}");
                        options.UseSqlServer("Server=.;Database=DertInfo;Integrated Security=true;");
                    }
                });
        }
    }
}