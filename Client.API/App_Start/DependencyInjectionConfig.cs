using Application.Client.Business.Client;
using Infrastructure.Client.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Client.API.App_Start
{
    public class DependencyInjectionConfig
    {
        protected DependencyInjectionConfig() { }
        public static void Register(IServiceCollection services) 
        {
            //Business
            services.AddScoped(typeof(IClientBusiness), typeof(ClientBusiness));

            //Repository
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            services.AddScoped(typeof(IHomeRepository), typeof(HomeRepository));
        }
    }
}
