using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Tweet.Mapping
{
    public class TweetMapRequestProfiler : Profile
    {
        public TweetMapRequestProfiler()
        {

            CreateMap<TagRequest, TweetTagEntity>()
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(_ => _));

            CreateMap<TweetRequest, TweetEntity>()
                
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.DataCriacao))
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(src => src.Idioma))
                .ForMember(dest => dest.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(d => d.Tags2, opt => opt.MapFrom(s => Mapper.Map<List<TagRequest>, ICollection<TagEntity>>(s.Tags)))

                //EJM
                //.ForMember(d => d.Tags, opt => opt.MapFrom(s => Mapper.Map<List<TagRequest>, ICollection<TweetTagEntity>>(s.Tags)))
                .ForMember(d => d.Pais, opt => opt.ResolveUsing(model => new PaisEntity(){Nome = model.Pais}))
                .ForMember(d => d.Idioma, opt => opt.ResolveUsing(model => new IdiomaEntity() { Nome = model.Idioma }))
                ;

            CreateMap<TweetEntity, TweetResponse>();
        }
    }
}
