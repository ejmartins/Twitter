using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Data.Repository
{
    public class PostagemPorDiaRepository : BaseRepositoryDw<PostagemPorDiaFato>, IPostagemPorDiaRepository
    {
        public PostagemPorDiaRepository(DatabaseContextDW dbContext) : base(dbContext)
        {

        }
        public override IQueryable<PostagemPorDiaFato> GetAll()
        {
            return base._dbContext.PostagemPorDiaFato.OrderByDescending(_ => _.Ano).ThenByDescending(_ => _.Mes).ThenByDescending(_ => _.Dia).ThenByDescending(_ => _.Hora);
        }


    }
}
