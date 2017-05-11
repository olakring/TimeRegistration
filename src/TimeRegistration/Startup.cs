using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(TimeRegistration.Startup))]

namespace TimeRegistration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            
            WebApiConfig.Register(config);

            config
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            
            
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            app.UseWebApi(config);

            ConfigureSwagger(config);
        }

        private void ConfigureSwagger(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Web Services");

                    c.UseFullTypeNameInSchemaIds();

                    var assembly = Assembly.GetExecutingAssembly();
                    var baseDirectory = Path.GetDirectoryName(assembly.CodeBase);
                    var commentsFileName = assembly.GetName().Name + ".XML";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    c.IncludeXmlComments(commentsFile);
                })
                .EnableSwaggerUi(c => c.DisableValidator());
        }
    }
}
