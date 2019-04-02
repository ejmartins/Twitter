using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Fatos
{
    public class PostagemPorDiaFato : BaseEntity, IFato
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public int QtdTweet { get; set; }
    }
}
