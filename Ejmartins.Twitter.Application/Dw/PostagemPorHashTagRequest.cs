using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Dw
{
    public class PostagemPorHashTagRequest
    {
        public int Id { get; set; }
        public string NomeHashTag { get; set; }
        public string Idioma { get; set; }

        public int QtdTweet { get; set; }
    }
}
