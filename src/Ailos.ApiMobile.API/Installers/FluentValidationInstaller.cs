﻿using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ailos.ApiMobile.API.Installers
{
    public class FluentValidationInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
                options.RegisterValidatorsFromAssembly(Assembly.Load("Ailos.Pix"));
                //options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
        }
    }
}
