using System.IO;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Swashbuckle.Application;
using TimeRegistration.Core.Managers.Abstructions;
using TimeRegistration.Core.Managers.Implementations;
using TimeRegistration.Core.Repositories.Abstructions;
using TimeRegistration.Core.Repositories.Implementations;

[assembly: OwinStartup(typeof(TimeRegistration.Api.Startup))]

namespace TimeRegistration.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();
            ConfigureSimpleInjector(container);

            var config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            WebApiConfig.Register(config);
            ConfigureSwagger(config);

            app.UseWebApi(config);
        }

        private void ConfigureSimpleInjector(Container container)
        {
            container.Register<IUserManager, UserManager>();
            container.Register<IUserRepository, UserRepository>();
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
