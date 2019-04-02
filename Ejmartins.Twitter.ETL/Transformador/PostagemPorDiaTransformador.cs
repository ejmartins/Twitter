using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.ETL.Transformador
{
    public class PostagemPorDiaTransformador : TransformadorBase<TweetResponse, PostagemPorDiaRequest>, IPostagemPorDiaTransformador
    {
        private ITweetService _serviceTwitter;
        private IDwService _serviceDw;

        public PostagemPorDiaTransformador(ITweetService serviceTwitter_, IDwService serviceDw_)
        {
            _serviceTwitter = serviceTwitter_;
            _serviceDw = serviceDw_;
        }

        public override List<TweetResponse> ExtrairDadosOrigem()
        {
            return _serviceTwitter.GetAll().ToList();
        }

        public override List<PostagemPorDiaRequest> TransformarDados(List<TweetResponse> dados)
        {
            List<PostagemPorDiaRequest> lista = new List<PostagemPorDiaRequest>();

            foreach (var item in dados.Select(x => x.DataCriacao.Date).Distinct())
            {
                for (int i = 0; i <= 23; i++)
                {
                    if(item.Date.Equals(DateTime.Now.Date) && i > DateTime.Now.Hour)
                        break;

                    int ano = item.Year;
                    int mes = item.Month;
                    int dia = item.Day;
                    int hora = i;
                    int qtd = dados.Where(_ => _.DataCriacao.Date.Equals(item) && _.DataCriacao.Hour.Equals(i))?.Count() ?? 0;

                    lista.Add(new PostagemPorDiaRequest()
                    {
                        Ano = ano,
                        Dia = dia,
                        Hora = hora,
                        Mes = mes,
                        QtdTweet = qtd,
                    });
                }

            }

            return lista;
        }

        public override void CarregarDados(List<PostagemPorDiaRequest> dados)
        {
            _serviceDw.CarregarPostagemPorDia(dados);
        }
    }
}