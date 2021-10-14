using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Middlewares
{
    public class ShowRegisteredServicesMiddleware : IMiddleware
    {
        private readonly ShowServicesOptions _options;

        public ShowRegisteredServicesMiddleware(ShowServicesOptions options)
        {
            _options = options;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path != _options.Path)
                return next(context);

            var sb = new StringBuilder();
            sb.Append("<h1>All Services</h1>");
            sb.Append("<table><thead>");
            sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
            sb.Append("</thead><tbody>");

            foreach (var service in _options.Services.Where(x => x.ServiceType.FullName.StartsWith("Ailos.")))
            {
                sb.Append("<tr>");
                sb.Append($"<td>{service.ServiceType.FullName}</td>");
                sb.Append($"<td>{service.Lifetime}</td>");
                sb.Append($"<td>{service.ImplementationType?.FullName}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table>");

            return context.Response.WriteAsync(sb.ToString());
        }
    }

    public class ShowServicesOptions
    {
        public ShowServicesOptions(IEnumerable<ServiceDescriptor> services) =>
            Services = services;

        public string Path { get; set; } = "/listallservices";

        public IEnumerable<ServiceDescriptor> Services { get; }
    }
}
