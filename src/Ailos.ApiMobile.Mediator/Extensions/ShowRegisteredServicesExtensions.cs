using Ailos.ApiMobile.Mediator.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShowRegisteredServicesExtensions
    {
        public static IServiceCollection AddShowRegisteredServices(this IServiceCollection services, Action<ShowServicesOptions> options = null)
        {
            var showOptions = new ShowServicesOptions(services);

            options?.Invoke(showOptions);

            services.AddSingleton(showOptions);
            services.AddSingleton<ShowRegisteredServicesMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseShowRegisteredServices(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ShowRegisteredServicesMiddleware>();
        }
    }
}
