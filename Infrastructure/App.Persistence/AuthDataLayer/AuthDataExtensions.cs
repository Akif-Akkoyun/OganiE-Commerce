using App.Persistence.AuthDataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.AuthDataLayer
{
    public static class AuthDataExtensions
    {
        public static void AddAuthDataLayer(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<DbContext,AuthDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
