using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Ailos.ApiMobile.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory;
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        // Response personalizado para a vailidação dos requests
        private IActionResult InvalidModelStateResponseFactory(ActionContext context)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(kvp => new
                {
                    FieldName = kvp.Key,
                    Messages = kvp.Value.Errors.Select(x => x.ErrorMessage)
                });

            return new BadRequestObjectResult(errors);
        }
    }
}
