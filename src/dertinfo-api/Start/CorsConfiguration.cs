using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DertInfo.Api.Start
{
    public static class CorsConfiguration 
    {
        public static void Build(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                var allowedCorsOriginsString = builder.Configuration["Cors:AllowedOrigins"];

                if (string.IsNullOrWhiteSpace(allowedCorsOriginsString))
                {
                    System.Diagnostics.Trace.TraceWarning("AllowedOrigins configuration is not set, using localhost");
                    allowedCorsOriginsString = "http://localhost:3000,http://localhost:4200";
                }

                var allowedCorsOriginsArray = allowedCorsOriginsString.Split(",");

                if (allowedCorsOriginsArray.Any(origin => !Uri.IsWellFormedUriString(origin.Trim(), UriKind.Absolute)))
                {
                    System.Diagnostics.Trace.TraceWarning("One or more AllowedOrigins are not valid URLs.");
                }

                options.AddPolicy("AllowSpecificOrigins",
                    policy =>
                    {
                        policy.WithOrigins(allowedCorsOriginsArray.Select(o => o.Trim()).ToArray())
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }
    }
}