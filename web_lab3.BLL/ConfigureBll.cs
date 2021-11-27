using System;
using System.Text;
using Abstractions;
using Abstractions.Auth;
using BLL.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BLL
{
    public class ConfigureBll : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("Jwt").Get<JwtTokenConfig>();
            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    // TODO In guide it is true
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
                        ValidateAudience = true,
                        ValidAudience = jwtConfig.Audience,
                        ValidateLifetime = true,
                        // TODO in guide is 1 minute
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddHostedService<JwtRefreshTokenCache>();
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}