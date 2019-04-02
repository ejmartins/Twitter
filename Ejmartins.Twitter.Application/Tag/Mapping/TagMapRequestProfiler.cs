using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Tag.Mapping
{
    public class TagMapRequestProfiler : Profile
    {

        public TagMapRequestProfiler()
        {
            CreateMap<TagRequest, TagEntity>();
            CreateMap<TagEntity, TagResponse>();
        }
    }
}
