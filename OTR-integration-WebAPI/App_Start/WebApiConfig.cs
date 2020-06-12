using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace OTR_integration_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            config.MapHttpAttributeRoutes();

            //Intercheck Accounts

            config.Routes.MapHttpRoute(
                "CreateDebitTransactionAsyncApi",
                "api/transactions/CreateDebitTransactionAsync",
                new { controller = "Transactions", action = "CreateDebitTransactionAsync" });
            config.Routes.MapHttpRoute(
                "CreateCreditTransactionAsyncApi",
                "api/transactions/CreateCreditTransactionAsync",
                new { controller = "Transactions", action = "CreateCreditTransactionAsync" });



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
        }
    }
}
