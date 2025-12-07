using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using System;

namespace DertInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                LoadConfiguration(config);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        private static void LoadConfiguration(IConfigurationBuilder config)
        {
            var appConfigurationUri = Environment.GetEnvironmentVariable("AZURE_APP_CONFIG");

            if (appConfigurationUri != null)
            {
                var settings = config.Build();

                var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true });

                config.AddAzureAppConfiguration(options =>
                {
                    options.Connect(new Uri(appConfigurationUri), credential)
                    .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                    .ConfigureKeyVault(kv =>
                    {
                        kv.SetCredential(credential);
                    });
                });
            }
        }
    }
}
