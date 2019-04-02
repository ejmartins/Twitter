using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Infra;
using Ejmartins.Twitter.Servico.Mapping;
using Ninject;
using Topshelf;

namespace Ejmartins.Twitter.Servico
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new NinjectConfig());
            kernal.Load(Assembly.GetExecutingAssembly());
            AutoMapperServicoConfig.RegisterMappings();

            string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            string accessToken = ConfigurationManager.AppSettings["accessToken"];
            string accessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"];
            string[] tags = ConfigurationManager.AppSettings["tags"].Split(',');

            Console.WriteLine("consumerKey: {0}", consumerKey);
            Console.WriteLine("consumerSecret: {0}", consumerSecret);
            Console.WriteLine("accessToken: {0}", accessToken);
            Console.WriteLine("accessTokenSecret: {0}", accessTokenSecret);
            Console.WriteLine("tags: {0}", string.Join(";", tags));

            AcessarTwitter.CopiarTweets(kernal.Get<ITweetService>(), kernal.Get<ITagService>(), consumerKey, consumerSecret, accessToken, accessTokenSecret, tags);

            Console.WriteLine("Fim do processo");
            Console.ReadKey();

        }
    }
}
