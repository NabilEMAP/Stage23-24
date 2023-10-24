using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Repositories;
using PlanningsTool.DAL.UOW;
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:Stage2324");

                // Set up a logger factory that doesn't log anything
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) => false)));
            });

            return services;
        }


        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IZorgkundigenRepository, ZorgkundigenRepository>();
            services.AddScoped<IRegimeTypesRepository, RegimeTypesRepository>();
            services.AddScoped<IVerlofTypesRepository, VerlofTypesRepository>();
            services.AddScoped<IShiftTypesRepository, ShiftTypesRepository>();
            return services;
        }

        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
