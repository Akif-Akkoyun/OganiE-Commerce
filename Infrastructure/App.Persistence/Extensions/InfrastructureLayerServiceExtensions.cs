using App.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Extensions
{
    public static class InfrastructureLayerServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, AppDbcontext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
