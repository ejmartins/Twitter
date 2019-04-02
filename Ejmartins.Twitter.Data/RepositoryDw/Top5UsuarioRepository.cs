using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Data.Repository
{
    public class Top5UsuarioRepository : BaseRepositoryDw<Top5UsuarioFato>, ITop5UsuarioRepository
    {
        public Top5UsuarioRepository(DatabaseContextDW dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Top5UsuarioFato> GetAll()
        {
            return base._dbContext.Top5Usuario.OrderByDescending(_ => _.Seguidores);
        }

    }
}
