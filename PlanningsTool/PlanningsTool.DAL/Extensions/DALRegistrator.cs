using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Repositories;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.DAL.Extensions
{
    public static class DALRegistrator
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:Stage2324");
            });

            return services;
        }


        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<INursesRepository, NursesRepository>();
            services.AddScoped<IRegimeTypesRepository, RegimeTypesRepository>();
            services.AddScoped<IVacationTypesRepository, VacationTypesRepository>();
            services.AddScoped<IShiftTypesRepository, ShiftTypesRepository>();
            services.AddScoped<IVacationsRepository, VacationsRepository>();
            services.AddScoped<IShiftsRepository, ShiftsRepository>();
            services.AddScoped<INurseShiftsRepository, NurseShiftsRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<ITeamplansRepository, TeamplansRepository>();
            services.AddScoped<IHolidaysRepository, HolidaysRepository>();
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
