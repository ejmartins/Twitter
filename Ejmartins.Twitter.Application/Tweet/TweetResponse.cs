using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Application.Idioma;
using Ejmartins.Twitter.Application.Tag;
using Ejmartins.Twitter.Application.Usuario;

namespace Ejmartins.Twitter.Application.Tweet
{
    public class TweetResponse
    {
        public TweetResponse()
        {
            Usuario = new UsuarioResponse();
            Tags2 = new List<TagResponse>();
            Pais = new PaisResponse();
            Idioma = new IdiomaResponse();
        }

        public string Mensagem { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual ICollection<TagResponse> Tags2 { get; set; }

        public PaisResponse Pais { get; set; }

        public IdiomaResponse Idioma { get; set; }

        public UsuarioResponse Usuario { get; set; }
    }
}
