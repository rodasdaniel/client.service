using Client.API.App_Start;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client.API
{
    public class Startup
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public Startup(IConfiguration configuration,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // (1) - Dependency Inyection
            DependencyInjectionConfig.Register(services);
            // (2) - AutoMapper Configuration
            AutoMapperConfig.Register(services);
            // (3) - Swagger Configuration
            SwaggerConfig.Register(services);
            // (4) - Setting Configuration
            AppSettingsConfig.Register(services, _env, Configuration);
            // (5) - 
            services.AddControllers();
            // (6) - Filters configurations
            FiltersConfig.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Swagger Configure
            SwaggerConfig.Configure(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
