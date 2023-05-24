using Management;
using Management.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NugetsVersionsManager.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICardJiraRepository, CardJiraRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IEpicFeatureRepository, EpicFeatureRepository>();
            services.AddScoped<IManagerVersionRepository, ManagerVersionRepository>();
            services.AddScoped<ISolutionRepository, SolutionRepository>();
            services.AddScoped<ISprintRepository, SprintRepository>();
        }
    }
}
