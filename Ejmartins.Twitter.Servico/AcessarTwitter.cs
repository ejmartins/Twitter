using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Tweet;
using Ejmartins.Twitter.Data;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Infra;
using Ninject;
using Tweetinvi.Models;

namespace Ejmartins.Twitter.Servico
{
    public static class AcessarTwitter
    {
        public static void CopiarTweets(ITweetService tweetService, ITagService tagService, string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, string[] tags)
        {
            Tweets lista = new Tweets(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var listaEntidadeRequest = Mapper.Map<List<ITweet>, List<TweetRequest>>(lista.GetAll(tags).ToList());

            tweetService.Create(listaEntidadeRequest);
        }
    }
}
