using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Entities
{
    public class TweetEntity : BaseEntity
    {

        public TweetEntity()
        {
            Usuario = new UsuarioEntity();
            Tags2 = new List<TagEntity>();
            Pais = new PaisEntity();
            Idioma = new IdiomaEntity();
        }

        public string Mensagem { get; set; }

        public DateTime DataCriacao { get; set; }

        //EJM
        //public virtual ICollection<TweetTagEntity> Tags { get; set; }

        public virtual ICollection<TagEntity> Tags2 { get; set; }

        public PaisEntity Pais { get; set; }

        public IdiomaEntity Idioma { get; set; }

        public UsuarioEntity Usuario { get; set; }

    }
}
