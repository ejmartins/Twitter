using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Fatos
{
    public class PostagemPorHashTagFato : BaseEntity, IFato
    {

        public string NomeHashTag { get; set; }

        public string Idioma { get; set; }
        
        public int QtdTweet { get; set; }
    }
}
