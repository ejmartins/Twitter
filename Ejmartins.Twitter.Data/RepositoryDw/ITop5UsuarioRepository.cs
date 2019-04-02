using System;
using System.Collections.Generic;
using System.Text;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Data.Repository
{
    public interface ITop5UsuarioRepository : IRepository<Top5UsuarioFato>
    {
    }
}
