using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Extensions
{
    public static class DALRegistrator
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            // Service AddDbContext moet hier nog toegevoegd worden
            // ...
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            // Service Scopes moeten hier nog toegevoegd worden
            // ...
            return services;
        }

        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
        {
            // Service Scopes moeten hier nog toegevoegd worden
            // ...
            return services;
        }

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            services.RegisterUnitOfWork();
            return services;
        }
    }
}
