using Application.Client.Common.Utils;
using Application.Client.Dtos;
using Infrastructure.Client.Data.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Client.API.App_Start
{
    public class AppSettingsConfig
    {
        protected AppSettingsConfig() { }

        public static void Register(IServiceCollection services, IHostingEnvironment _env,
            IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            //options.UseSqlServer("Persist Security Info = False; User ID = sa; Password = n4cion4ly.; Initial Catalog = Sistecredito; Server = DESKTOP-LJNH78V",
            options.UseSqlServer(GetEnvVariable.Get(_env, "dbconnection", Configuration),
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
