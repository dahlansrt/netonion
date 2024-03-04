using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Extensions
{
    public static class PersistenceStartupExtension
    {
        /// <summary>
        /// Todo:
        /// Read configuration and add context by configuration.
        /// Example: MSSQL, PostgreSQL, MySql, MongoDB, 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddPersistence(this IServiceCollection services, IConfiguration? configuration = null)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(opt => opt.UseInMemoryDatabase("Onion"));
        }
    }
}
