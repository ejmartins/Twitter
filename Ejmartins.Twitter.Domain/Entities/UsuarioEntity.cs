using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int Seguidores { get; set; }


    }
}
