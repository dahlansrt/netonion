using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ApplicationStartupExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
