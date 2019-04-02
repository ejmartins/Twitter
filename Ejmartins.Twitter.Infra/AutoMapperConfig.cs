using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Application.Dw.Mapping;
using Ejmartins.Twitter.Application.Tag.Mapping;
using Ejmartins.Twitter.Application.Tweet.Mapping;
using Ejmartins.Twitter.Application.Usuario.Mapping;

namespace Ejmartins.Twitter.Infra
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(_ =>
            {
                _.AddProfile(new TagMapRequestProfiler());
                _.AddProfile(new TweetMapRequestProfiler());
                _.AddProfile(new UsuarioMapRequestProfiler());
                _.AddProfile(new PaisMapProfiler());
                _.AddProfile(new IdiomaMapProfiler());
                _.AddProfile(new DwProfiler());
            });
        }
    }
}
