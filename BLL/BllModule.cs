﻿using System.Reflection;
using Abstractions.Entities;
using Autofac;
using AutoMapper;
using BLL.Identity;
using Microsoft.AspNetCore.Identity;
using Module = Autofac.Module;

namespace BLL
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //configure all services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //Configure AutoMapper
            // TODO
            builder.RegisterInstance(new MapperConfiguration(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); })
                .CreateMapper());

            builder.RegisterType<ClaimsPrincipalFactory>()
                .As<IUserClaimsPrincipalFactory<User>>();
        }
    }
}