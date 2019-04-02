using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Dw
{
    public class PostagemPorDiaRequest
    {
        public int Id { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public int QtdTweet { get; set; }
    }
}
