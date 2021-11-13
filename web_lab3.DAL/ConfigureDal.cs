using System;
using Abstractions;
using Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class ConfigureDal : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
            if (development)
            {
                serviceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
            }
        }
    }
}