using Ejmartins.Twitter.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<UsuarioResponse> GetAll()
        {
            var list = Mapper.Map<List<UsuarioEntity>, List<UsuarioResponse>>(_repository.GetAll().ToList());
            return list;
        }

        public int Create(UsuarioRequest request)
        {
            var entity = Mapper.Map<UsuarioRequest, UsuarioEntity>(request);
            _repository.Create(entity);
            _repository.SaveChanges();
            return entity.Id;
        }

    }
}
