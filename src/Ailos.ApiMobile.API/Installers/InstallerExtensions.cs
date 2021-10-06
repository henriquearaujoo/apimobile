﻿using Ailos.ApiMobile.API.Installers;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstallerExtensions
    {
        public static IServiceCollection AddInstallers(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = Assembly.GetExecutingAssembly().ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>();

            foreach (var installer in installers)
                installer.InstallerServices(services, configuration);

            return services;
        }
    }
}
