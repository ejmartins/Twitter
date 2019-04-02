using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag.Mapping;
using Ejmartins.Twitter.Application.Tweet.Mapping;
using Ejmartins.Twitter.Application.Usuario.Mapping;
using Ejmartins.Twitter.Infra;
using Ninject;

namespace Ejmartins.Twitter.Servico.Mapping
{
    public static class AutoMapperServicoConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(_ =>
            {
                _.AddProfile(new TagMapRequestProfiler());
                _.AddProfile(new TweetMapRequestProfiler());
                _.AddProfile(new UsuarioMapRequestProfiler());
                _.AddProfile(new TweetMapProfiler());
            });
        }
    }
}
