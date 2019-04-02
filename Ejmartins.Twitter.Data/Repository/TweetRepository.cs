using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Repository
{
    public class TweetRepository : BaseRepository<TweetEntity>, ITweetRepository
    {
        public TweetRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<TweetEntity> GetAll()
        {
            return base._dbContext.Tweets.Include("Usuario").Include("Pais").Include("Idioma");
        }


        public void Create(List<TweetEntity> entity)
        {
            base._dbContext.Tweets.AddRange(entity);
        }
    }
}
