using System;
using System.Reflection;
using System.Web.Http;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Application.Usuario;
using Ejmartins.Twitter.API;
using Microsoft.Owin;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Ejmartins.Twitter.Data;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Infra;

[assembly: OwinStartupAttribute("GatorsConfig", typeof(Ejmartins.Twitter.API.Startup))]

namespace Ejmartins.Twitter.API
{
    public class Startup
    {
        public IKernel ConfigureNinject(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var kernel = CreateKernel();
            app.UseNinjectMiddleware(() => kernel);
            app.UseNinjectWebApi(config);

            return kernel;
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        public static void ConfigureAuth(IAppBuilder app, IKernel kernel)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));
            var kernel = ConfigureNinject(app);
            ConfigureAuth(app, kernel);
        }
    }

    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Kernel.Bind<IDatabaseContext>().To<DatabaseContext>();

            Kernel.Bind<ITagRepository>().To<TagRepository>();
            Kernel.Bind<ITagService>().To<TagService>();

            Kernel.Bind<ITweetRepository>().To<TweetRepository>();
            Kernel.Bind<ITweetService>().To<TweetService>();

            Kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Kernel.Bind<IUsuarioService>().To<UsuarioService>();

            Kernel.Bind<IPaisRepository>().To<PaisRepository>();
            Kernel.Bind<IIdiomaRepository>().To<IdiomaRepository>();

            Kernel.Bind<IDwService>().To<DwService>();
            Kernel.Bind<ITop5UsuarioRepository>().To<Top5UsuarioRepository>();
            Kernel.Bind<IPostagemPorHashTagRepository>().To<PostagemPorHashTagRepository>();
            Kernel.Bind<IPostagemPorDiaRepository>().To<PostagemPorDiaRepository>();
            Kernel.Bind<IDatabaseContextDw>().To<DatabaseContextDW>();

        }
    }


}
