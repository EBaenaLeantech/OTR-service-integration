using OTR_integration_WebAPI.ApiSettings;
using OTR_integration_WebAPI.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace OTR_integration_WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IInterchecksApiSettings, InterchecksApiSettings>();
            container.RegisterType<ITransactionsService, TransactionsService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}