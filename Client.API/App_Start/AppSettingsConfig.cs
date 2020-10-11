using Application.Client.Dtos;
using Infrastructure.Client.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Client.API.App_Start
{
    public class AppSettingsConfig
    {
        protected AppSettingsConfig() { }

        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer("Persist Security Info = False; User ID = sa; Password = n4cion4ly.; Initial Catalog = Sistecredito; Server = DESKTOP-LJNH78V",
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            }));
        }
    }
}
