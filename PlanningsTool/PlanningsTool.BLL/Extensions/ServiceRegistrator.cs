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
            services.AddScoped<INursesService, NursesService>();
            services.AddScoped<IRegimeTypesService, RegimeTypesService>();
            services.AddScoped<IVacationTypesService, VacationTypesService>();
            services.AddScoped<IShiftTypesService, ShiftTypesService>();
            services.AddScoped<IVacationsService, VacationsService>();
            services.AddScoped<IShiftsService, ShiftsService>();
            services.AddScoped<INurseShiftsService, NurseShiftService>();
            services.AddScoped<ITeamplansService, TeamplansService>();
            services.AddScoped<ITeamsService, TeamsService>();
            services.AddScoped<IShiftsService, ShiftsService>();
            services.AddScoped<IHolidaysService, HolidaysService>();
            services.AddScoped<IExcelService, ExcelService>();
            services.RegisterValidators();
            return services;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateNurseValidator>();
            services.AddTransient<UpdateNurseValidator>();
            services.AddTransient<CreateVacationValidator>();
            services.AddTransient<UpdateVacationValidator>();
            services.AddTransient<CreateNurseShiftValidator>();
            services.AddTransient<UpdateNurseShiftValidator>();
            services.AddTransient<CreateTeamplanValidator>();
            services.AddTransient<UpdateTeamplanValidator>();
            services.AddTransient<CreateTeamValidator>();
            services.AddTransient<UpdateTeamValidator>();
            services.AddTransient<CreateHolidayValidator>();
            services.AddTransient<UpdateHolidayValidator>();
            return services;
        }

        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
