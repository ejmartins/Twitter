using System;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Application.Usuario;
using Ejmartins.Twitter.Data;
using Ejmartins.Twitter.Data.Repository;
using Ninject.Modules;

namespace Ejmartins.Twitter.Infra
{
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
