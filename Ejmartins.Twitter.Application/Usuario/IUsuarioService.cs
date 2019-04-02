using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Usuario
{
    public interface IUsuarioService
    {
        List<UsuarioResponse> GetAll();

        int Create(UsuarioRequest request);

    }
}
