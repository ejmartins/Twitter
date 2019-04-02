using Ejmartins.Twitter.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Application.Tweet
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IIdiomaRepository _idiomaRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly ITagRepository _tagRepository;



        public TweetService(ITweetRepository repository, IUsuarioRepository usuarioRepository, IIdiomaRepository idiomaRepository, IPaisRepository paisRepository, ITagRepository tagRepository)
        {
            _tweetRepository = repository;
            _usuarioRepository = usuarioRepository;
            _idiomaRepository = idiomaRepository;
            _paisRepository = paisRepository;
            _tagRepository = tagRepository;
        }

        public List<TweetResponse> GetAll()
        {
            var list = Mapper.Map<List<TweetEntity>, List<TweetResponse>>(_tweetRepository.GetAll().ToList());
            return list;
        }

        public void Create(List<TweetRequest> request)
        {
            var entity = Mapper.Map<List<TweetRequest>, List<TweetEntity>>(request);
            LimparBase();
            _tweetRepository.Create(PrepararInsert(entity));
            _tweetRepository.SaveChanges();
        }

        private List<TweetEntity> PrepararInsert(List<TweetEntity> entity)
        {
            List<TagEntity> listaTag = entity.SelectMany(x => x.Tags2).Distinct().ToList();
            List<PaisEntity> listaPais = entity.Select(x => x.Pais).Distinct().ToList();
            List<UsuarioEntity> listaUsuario = entity.Select(x => x.Usuario).Distinct().ToList();
            List<IdiomaEntity> listaIdioma = entity.Select(x => x.Idioma).Distinct().ToList();

            List<TweetEntity> inserir = new List<TweetEntity>();

            foreach (var item in entity)
            {
                var itemPreparado = new TweetEntity();
                itemPreparado.DataCriacao = item.DataCriacao;
                itemPreparado.Mensagem = item.Mensagem;
                itemPreparado.Pais = listaPais?.Where(x => x.Nome == item?.Pais?.Nome)?.FirstOrDefault() ?? new PaisEntity();
                itemPreparado.Idioma = listaIdioma?.Where(x => x.Nome == item?.Idioma?.Nome)?.FirstOrDefault() ?? new IdiomaEntity();
                itemPreparado.Usuario = listaUsuario?.Where(x => x.Nome == item?.Usuario?.Nome)?.FirstOrDefault() ?? new UsuarioEntity();

                //EJM
                foreach (var itemTag in item.Tags2)
                {
                    itemPreparado.Tags2.Add(listaTag.Where(x => x.Descricao == itemTag.Descricao).FirstOrDefault() ?? new TagEntity());
                }

                inserir.Add(itemPreparado);
            }

            return inserir;
        }

        private void LimparBase()
        {
            _tweetRepository.DeleteAll();
            _tweetRepository.SaveChanges();

            _usuarioRepository.DeleteAll();
            _usuarioRepository.SaveChanges();

            _idiomaRepository.DeleteAll();
            _idiomaRepository.SaveChanges();

            _paisRepository.DeleteAll();
            _paisRepository.SaveChanges();

            _tagRepository.DeleteAll();
            _tagRepository.SaveChanges();

        }

        public int Create(TweetRequest request)
        {
            var entity = Mapper.Map<TweetRequest, TweetEntity>(request);
            _tweetRepository.Create(entity);
            _tweetRepository.SaveChanges();
            return entity.Id;
        }

    }
}
