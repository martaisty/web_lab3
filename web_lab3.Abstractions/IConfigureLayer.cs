using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Abstractions
{
    public interface IConfigureLayer
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void Configure(IServiceProvider serviceProvider, bool development);
    }
}