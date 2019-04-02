using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Entities
{
    public class TagEntity : BaseEntity
    {
        public string Descricao { get; set; }


        //EJM
        //public virtual ICollection<TweetTagEntity> Tweets { get; set; }


        public virtual ICollection<TweetEntity> Tweets2 { get; set; }

    }
}
