using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace DertInfo.Api.Start
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Build(WebApplicationBuilder builder)
        {
            MapperConfiguration mapperConfiguration = null;
            try
            {
                var imagesStorageAccount = builder.Environment.IsDevelopment()
                    ? $"http://127.0.0.1:10000/{builder.Configuration["StorageAccount:Images:Name"]}"
                    : $"https://{builder.Configuration["StorageAccount:Images:Name"]}.blob.core.windows.net";

                mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DertInfo.Api.Core.AutoMapperProfileConfiguration(imagesStorageAccount));
                });

                return mapperConfiguration;
            }
            catch (Exception ex)
            {
                throw new Exception($"AutoMapper configuration error: {ex.Message}", ex);
            }
        }
    }
}