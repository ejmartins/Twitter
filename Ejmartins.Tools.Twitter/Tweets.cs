using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejmartins.Tools.Twitter
{
    public class Tweets : IDisposable
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _accessToken;
        private string _accessTokenSecret;


        public Tweets(string consumerKey_, string consumerSecret_, string accessToken_, string accessTokenSecret_)
        {
            _consumerKey = consumerKey_;
            _consumerSecret = consumerSecret_;
            _accessToken = accessToken_;
            _accessTokenSecret = accessTokenSecret_;
            //Auth.SetUserCredentials(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
        }

        //public IEnumerable<ITweet> GetAll(string[] tags)
        //{
        //    List<ITweet> lista = new List<ITweet>();

        //    foreach (var tag in tags)
        //    {
        //        lista.AddRange(Search.SearchTweets(tag).ToList());
        //    }

        //    return lista;
        //}

        public void Dispose()
        {
          //TODO: Implementar Logout
        }
    }
}
