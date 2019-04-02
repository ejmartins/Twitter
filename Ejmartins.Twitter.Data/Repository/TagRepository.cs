using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Repository
{
    public class TagRepository : BaseRepository<TagEntity>, ITagRepository
    {
        public TagRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
