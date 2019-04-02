using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.Domain.Fatos
{
    public class Top5UsuarioFato : BaseEntity, IFato
    {
        public string Nome { get; set; }
        public int Seguidores { get; set; }

    }
}
