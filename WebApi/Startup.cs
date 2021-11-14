using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Abstractions;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web_lab3
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _environment;

        private readonly List<Assembly> _assemblies;

        private readonly List<IConfigureLayer> _layerConfigurations = new();

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _configuration = configuration;
            _environment = environment;

            //Load assemblies
            _assemblies =
                Directory.EnumerateFiles(Directory.GetCurrentDirectory(),
                        $"{nameof(web_lab3)}.*.dll", SearchOption.AllDirectories)
                    .Select(Assembly.LoadFrom)
                    .ToList();
            _assemblies.Add(Assembly.GetExecutingAssembly());

            //load configurations
            foreach (var assembly in _assemblies)
            {
                var configure = typeof(IConfigureLayer);
                var types = assembly.GetTypes().Where((t) => configure.IsAssignableFrom(t) && !t.IsAbstract);
                foreach (var type in types)
                {
                    _layerConfigurations.Add((IConfigureLayer) Activator.CreateInstance(type));
                }
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        // This policy will change on Azure.
                        builder.WithOrigins(_configuration.GetSection("AllowedOrigins").ToString())
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                    });
            });

            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.ConfigureServices(services, _configuration);
            }
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            foreach (var assembly in _assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1"); });

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.Configure(serviceProvider, _environment.IsDevelopment());
            }
        }
    }
}