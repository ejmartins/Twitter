using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Dw
{
    public interface IDwService
    {
        void CarregarPostagemPorDia(List<PostagemPorDiaRequest> request);
        void CarregarPostagemPorHashTag(List<PostagemPorHashTagRequest> request);
        void CarregarTop5Usuario(List<Top5UsuarioRequest> request);
        List<PostagemPorDiaResponse> ListarPostagemPorDia();
        List<PostagemPorHashTagResponse> ListarPostagemPorHashTag();
        List<Top5UsuarioResponse> ListarTop5Usuario();
    }
}
