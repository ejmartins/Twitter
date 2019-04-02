using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Application.Dw
{
    public class DwService : IDwService
    {
        private readonly ITop5UsuarioRepository _repositoryTop5;
        private readonly IPostagemPorDiaRepository _repositoryPostagemPorDia;
        private readonly IPostagemPorHashTagRepository _repositoryPostagemPorHashTag;


        public DwService(ITop5UsuarioRepository repositoryTop5_, IPostagemPorDiaRepository repositoryPostagemPorDia_, IPostagemPorHashTagRepository repositoryPostagemPorHashTag_)
        {
            _repositoryTop5 = repositoryTop5_;
            _repositoryPostagemPorDia = repositoryPostagemPorDia_;
            _repositoryPostagemPorHashTag = repositoryPostagemPorHashTag_;
        }

        public void CarregarPostagemPorDia(List<PostagemPorDiaRequest> request)
        {
            var entity = Mapper.Map<List<PostagemPorDiaRequest>, List<PostagemPorDiaFato>>(request);
            _repositoryPostagemPorDia.DeleteAll();
            _repositoryPostagemPorDia.CreateAll(entity);
            _repositoryPostagemPorDia.SaveChanges();
        }

        public void CarregarPostagemPorHashTag(List<PostagemPorHashTagRequest> request)
        {
            var entity = Mapper.Map<List<PostagemPorHashTagRequest>, List<PostagemPorHashTagFato>>(request);
            _repositoryPostagemPorHashTag.DeleteAll();
            _repositoryPostagemPorHashTag.CreateAll(entity);
            _repositoryPostagemPorHashTag.SaveChanges();
        }
        public void CarregarTop5Usuario(List<Top5UsuarioRequest> request)
        {
            var entity = Mapper.Map<List<Top5UsuarioRequest>, List<Top5UsuarioFato>>(request);
            _repositoryTop5.DeleteAll();
            _repositoryTop5.CreateAll(entity);
            _repositoryTop5.SaveChanges();
        }
        public List<PostagemPorDiaResponse> ListarPostagemPorDia()
        {
            var list = Mapper.Map<List<PostagemPorDiaFato>, List<PostagemPorDiaResponse>>(_repositoryPostagemPorDia.GetAll().ToList());
            return list;
        }
        public List<PostagemPorHashTagResponse> ListarPostagemPorHashTag()
        {
            var list = Mapper.Map<List<PostagemPorHashTagFato>, List<PostagemPorHashTagResponse>>(_repositoryPostagemPorHashTag.GetAll().ToList());
            return list;
        }
        public List<Top5UsuarioResponse> ListarTop5Usuario()
        {
            var list = Mapper.Map<List<Top5UsuarioFato>, List<Top5UsuarioResponse>>(_repositoryTop5.GetAll().ToList());
            return list;
        }
    }
}
