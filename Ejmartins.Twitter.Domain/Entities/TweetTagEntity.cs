using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Entities
{
    public class TweetTagEntity : BaseEntity
    {

        public TweetTagEntity()
        {

        }

        public int IdTag { get; set; }

        public int IdTweet { get; set; }

        public virtual TagEntity Tag { get; set; }

        public virtual TweetEntity Tweet { get; set; }

    }
}
