using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Application.Usuario;
using Tweetinvi.Models;
using Tweetinvi.Models.Entities;

namespace Ejmartins.Twitter.Servico.Mapping
{
    public class TweetMapProfiler : Profile
    {

        public TweetMapProfiler()
        {

            CreateMap<IUser, UsuarioRequest>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seguidores, opt => opt.MapFrom(src => src.FollowersCount));

            CreateMap<IHashtagEntity, TagRequest>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Text));

            CreateMap<ITweet, TweetRequest>()
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(src => src.Language.ToString()))
                .ForMember(dest => dest.Mensagem, opt => opt.MapFrom(src => src.FullText))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.CreatedBy.Location))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Hashtags))
                .ForMember(d => d.Usuario, opt => opt.MapFrom(s => Mapper.Map<IUser, UsuarioRequest>(s.CreatedBy)));





            ;

        }
    }
}
