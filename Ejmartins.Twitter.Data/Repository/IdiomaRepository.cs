using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Repository
{
    public class IdiomaRepository : BaseRepository<IdiomaEntity>, IIdiomaRepository
    {
        public IdiomaRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
