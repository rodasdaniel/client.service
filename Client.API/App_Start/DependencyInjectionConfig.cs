﻿using Application.Client.Business.Client;
using Infrastructure.Client.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

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

            //Agents
            //services.AddScoped(typeof(IInfoClientProvider), typeof(InfoClientProvider));

        }
    }
}
