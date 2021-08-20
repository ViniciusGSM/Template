using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Template.IoC //Invertion of Controll - injecao de dependencias e inversao de controles
{
    public static class NativeInjector //metodo responsavel pela injecao de dependencia. precisa ser estatica que sera chamada la no startup.
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();
            //agora precisa setar ele no startup para carregar essa configuracao quando cerregar o projeto, sob pena dele ser ignorado.

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();


            #endregion
        }
    }
}
