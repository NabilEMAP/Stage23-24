using Microsoft.Extensions.DependencyInjection;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.BLL.Validations;
using System.Reflection;

namespace PlanningsTool.BLL.Extensions
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHolidaysService, HolidaysService>();
            services.AddScoped<INursesService, NursesService>();
            services.AddScoped<INurseShiftsService, NurseShiftService>();
            services.AddScoped<IShiftsService, ShiftsService>();
            services.AddScoped<ITeamsService, TeamsService>();
            services.AddScoped<ITeamplansService, TeamplansService>();
            services.AddScoped<IRegimeTypesService, RegimeTypesService>();
            services.AddScoped<IShiftTypesService, ShiftTypesService>();
            services.AddScoped<IVacationTypesService, VacationTypesService>();
            services.AddScoped<IVacationsService, VacationsService>();
            services.RegisterValidators();
            return services;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateHolidayValidator>();
            services.AddTransient<UpdateHolidayValidator>();
            services.AddTransient<CreateNurseValidator>();
            services.AddTransient<UpdateNurseValidator>();
            services.AddTransient<CreateNurseShiftValidator>();
            services.AddTransient<UpdateNurseShiftValidator>();
            services.AddTransient<CreateTeamplanValidator>();
            services.AddTransient<UpdateTeamplanValidator>();
            services.AddTransient<CreateTeamValidator>();
            services.AddTransient<UpdateTeamValidator>();
            services.AddTransient<CreateVacationValidator>();
            services.AddTransient<UpdateVacationValidator>();
            return services;
        }

        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
