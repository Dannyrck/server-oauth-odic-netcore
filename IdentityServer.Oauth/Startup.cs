using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer.Oauth.InMemoryConfigurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Oauth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var signinCertificate = Path.Combine(_env.ContentRootPath, String.Format("Certificates/test.pfx")); //variable que contiene el certificado para las firmas
            var passwordSignin = "test"; // password con el que se protegio el certificado.pfx
            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(@"C:\Users\Danny\source\otherRepos\netcoreIdentitySamples\IdentityPlueralSight\IdentityServer.Oauth\Certificates\test.pfx", passwordSignin)) // utilizar para produccion Certificado x509 para firma
                //.AddDeveloperSigningCredential() // solo para desarrollo
                .AddTestUsers(InMemoryConfiguration.Users().ToList())
                .AddInMemoryClients(InMemoryConfiguration.Clents())
                .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env 
            //, ILoggingBuilder loggerFactory
            )
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}
