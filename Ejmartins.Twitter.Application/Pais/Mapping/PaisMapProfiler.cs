using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Idioma;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Tag.Mapping
{
    public class PaisMapProfiler : Profile
    {

        public PaisMapProfiler()
        {
            CreateMap<PaisRequest, PaisEntity>();
            CreateMap<PaisEntity, PaisResponse>();
        }
    }
}
