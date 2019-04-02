using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.ETL.Transformador
{
    public class PostagemPorHashTagTransformador : TransformadorBase<TweetResponse, PostagemPorHashTagRequest>, IPostagemPorHashTagTransformador
    {
        private ITweetService _serviceTwitter;
        private IDwService _serviceDw;

        public PostagemPorHashTagTransformador(ITweetService serviceTwitter_, IDwService serviceDw_)
        {
            _serviceTwitter = serviceTwitter_;
            _serviceDw = serviceDw_;
        }

        public override List<TweetResponse> ExtrairDadosOrigem()
        {
            return _serviceTwitter.GetAll().ToList();
        }

        public override List<PostagemPorHashTagRequest> TransformarDados(List<TweetResponse> dados)
        {
            List<PostagemPorHashTagRequest> lista = new List<PostagemPorHashTagRequest>();

            string[] tags = ConfigurationManager.AppSettings["tags"].Replace("#","").Split(',');

            var listaPais = dados.Select(x => new {idioma = x.Idioma.Nome}).Distinct().ToList();
            var listaTag = dados.SelectMany(x => x.Tags2).Where(_ => tags.Contains(_.Descricao)).Select(_ => _.Descricao).Distinct().ToList();

            foreach (var tag in listaTag)
            {
                foreach (var pais in listaPais)
                {
                    int qtd = dados.Where(_ => _.Tags2.Where(z => z.Descricao == tag).Count() > 0
                                               && _.Idioma.Nome.Equals(pais.idioma)).Count();
                    if(qtd.Equals(0))
                        continue;

                    lista.Add(new PostagemPorHashTagRequest()
                    {
                        Idioma = pais.idioma,
                        NomeHashTag = tag,
                        QtdTweet = qtd
                    });

                }

            }
            return lista;
        }

        public override void CarregarDados(List<PostagemPorHashTagRequest> dados)
        {
            _serviceDw.CarregarPostagemPorHashTag(dados);
        }
    }
}
