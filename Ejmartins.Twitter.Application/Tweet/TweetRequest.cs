using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Usuario;

namespace Ejmartins.Twitter.Application.Tweet
{
    public class TweetRequest
    {

        public TweetRequest()
        {
               Tags = new List<TagRequest>(); 
               Usuario = new UsuarioRequest();
        }

        public string Mensagem { get; set; }

        public DateTime DataCriacao { get; set; }

        public List<TagRequest> Tags { get; set; }

        public UsuarioRequest Usuario { get; set; }

        public string Pais { get; set; }

        public string Idioma { get; set; }
    }
}
