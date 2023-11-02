using Microsoft.Extensions.DependencyInjection;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.BLL.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Extensions
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IZorgkundigenService, ZorgkundigenService>();
            services.AddScoped<IRegimeTypesService, RegimeTypesService>();
            services.AddScoped<IVerlofTypesService, VerlofTypesService>();
            services.AddScoped<IShiftTypesService, ShiftTypesService>();
            services.AddScoped<IVerlovenService, VerlovenService>();
            services.AddScoped<IShiftsService, ShiftsService>();
            services.AddScoped<IZorgkundigeShiftsService, ZorgkundigeShiftService>();
            services.AddScoped<ITeamplanningenService, TeamplanningenService>();
            services.AddScoped<IShiftsService, ShiftsService>();
            services.AddScoped<IFeestdagenService, FeestdagenService>();
            services.AddTransient<CreateZorgkundigeValidator>();
            return services;
        }

        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
