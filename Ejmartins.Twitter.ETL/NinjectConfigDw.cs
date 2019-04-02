using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Application.Usuario;
using Ejmartins.Twitter.Data;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;
using Ejmartins.Twitter.ETL.Transformador;
using Ninject.Modules;

namespace Ejmartins.Twitter.ETL
{
    public class NinjectConfigDw : NinjectModule
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

            Kernel.Bind<IPostagemPorDiaRepository>().To<PostagemPorDiaRepository>();
            Kernel.Bind<IPostagemPorHashTagRepository>().To<PostagemPorHashTagRepository>();
            Kernel.Bind<ITop5UsuarioRepository>().To<Top5UsuarioRepository>();


            Kernel.Bind<IPostagemPorDiaTransformador>().To<PostagemPorDiaTransformador>();
            Kernel.Bind<IPostagemPorHashTagTransformador>().To<PostagemPorHashTagTransformador>();
            Kernel.Bind<ITop5UsuarioTransformador>().To<Top5UsuarioTransformador>();

            Kernel.Bind<IDwService>().To<DwService>();

        }

    }
}
