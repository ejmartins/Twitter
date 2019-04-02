using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Usuario.Mapping
{
    public class UsuarioMapRequestProfiler : Profile
    {
        public UsuarioMapRequestProfiler()
        {
            CreateMap<UsuarioRequest, UsuarioEntity>();
            CreateMap<UsuarioEntity, UsuarioResponse>();
        }
    }
}
