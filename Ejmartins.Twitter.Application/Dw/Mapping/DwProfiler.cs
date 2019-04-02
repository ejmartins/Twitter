using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Usuario;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Application.Dw.Mapping
{
    public class DwProfiler : Profile
    {
        public DwProfiler()
        {
            CreateMap<UsuarioEntity, Top5UsuarioFato>();

            CreateMap<Top5UsuarioRequest, Top5UsuarioFato>();
            CreateMap<Top5UsuarioFato, Top5UsuarioResponse>();

            CreateMap<PostagemPorDiaRequest, PostagemPorDiaFato>();
            CreateMap<PostagemPorDiaFato, PostagemPorDiaResponse>();

            CreateMap<PostagemPorHashTagRequest, PostagemPorHashTagFato>();
            CreateMap<PostagemPorHashTagFato, PostagemPorHashTagResponse>();

            CreateMap<UsuarioResponse, Top5UsuarioRequest>();

        }
    }
}
