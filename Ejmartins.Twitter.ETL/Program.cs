using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;
using Ejmartins.Twitter.ETL.Transformador;
using Ejmartins.Twitter.Infra;
using Ninject;

namespace Ejmartins.Twitter.ETL
{
    class Program
    {
        static void Main(string[] args)
        {

            IKernel kernal = new StandardKernel(new NinjectConfigDw());
            AutoMapperConfig.RegisterMappings();

            var transformadorTop5 = kernal.Get<ITop5UsuarioTransformador>();
            var transformadorPorHashTagFato = kernal.Get<IPostagemPorHashTagTransformador>();
            var transformadorPostagemPorDia = kernal.Get<IPostagemPorDiaTransformador>();

            Console.WriteLine("Iniciando carga do Top 5");
            transformadorTop5.Executar();
            Console.WriteLine("Iniciando carga de Postagem por dia");
            transformadorPostagemPorDia.Executar();
            Console.WriteLine("Iniciando carga de Postagem por #");
            transformadorPorHashTagFato.Executar();

            Console.WriteLine("Fim do processamento");
            Console.ReadKey();

        }
    }
}
