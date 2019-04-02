using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Repository
{
    public interface ITweetRepository : IRepository<TweetEntity>
    {
        void Create(List<TweetEntity> entity);
    }
}
