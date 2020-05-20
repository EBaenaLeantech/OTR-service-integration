using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OTR_integration_API.ApiSettings;
using OTR_integration_API.Services;

namespace OTR_integration_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                 .AddNewtonsoftJson(s =>
                 {
                     s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                 })
                 .AddXmlSerializerFormatters();
            services.AddCors();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Repositories section
            //Same for every request, only for performance issues
            //services.AddSingleton<IRecipientsService, RecipientsService>();
            //Created once per client request
            services.AddScoped<IRecipientsService, RecipientsService>();

            //HttpClient Section Configuration
            services.AddHttpClient("InterchecksApi", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("InterchecksApiSettings:BaseUrl").Value);
                // API ContentType
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                //Api Authentication
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Configuration.GetSection("InterchecksApiSettings:AccountId").Value}:{Configuration.GetSection("InterchecksApiSettings:SecretKey").Value}")));

            });
            services.Configure<InterchecksApiSettings>(Configuration.GetSection("InterchecksApiSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    var result = JsonConvert.SerializeObject(new { error = exception.Message });
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }));
            }
            else
            {
                //Error handling in production environment
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    var result = JsonConvert.SerializeObject(new { error = exception.Message });
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
