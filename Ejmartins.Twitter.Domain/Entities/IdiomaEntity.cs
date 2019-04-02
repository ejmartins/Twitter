using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Entities
{
    public class IdiomaEntity : BaseEntity
    {
        public string Nome { get; set; }

        public virtual ICollection<TweetEntity> Tweets2 { get; set; }


    }
}
