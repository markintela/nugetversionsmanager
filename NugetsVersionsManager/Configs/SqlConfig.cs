using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NugetsVersionsManager.Configs
{
    public static class SqlConfig
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var database = configuration.GetConnectionString("sqlitedb");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(database);

            });

        }
    }
}
