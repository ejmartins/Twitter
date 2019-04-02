using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Data.Repository
{
    public class PostagemPorHashTagRepository : BaseRepositoryDw<PostagemPorHashTagFato>, IPostagemPorHashTagRepository
    {
        public PostagemPorHashTagRepository(DatabaseContextDW dbContext) : base(dbContext)
        {

        }

        public override IQueryable<PostagemPorHashTagFato> GetAll()
        {
            return base._dbContext.PostagemPorHashTag.OrderBy(_ => _.NomeHashTag).ThenBy(_ => _.Idioma).ThenBy(_ => _.QtdTweet);
        }

    }
}