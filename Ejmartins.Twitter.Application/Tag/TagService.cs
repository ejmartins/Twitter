using Ejmartins.Twitter.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Tag
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public List<TagResponse> GetAll()
        {
            var list = Mapper.Map<List<TagEntity>, List<TagResponse>>(_repository.GetAll().ToList());
            return list;
        }

        public int Create(TagRequest request)
        {
            var entity = Mapper.Map<TagRequest, TagEntity>(request);
            _repository.Create(entity);
            _repository.SaveChanges();
            return entity.Id;
        }

    }
}
