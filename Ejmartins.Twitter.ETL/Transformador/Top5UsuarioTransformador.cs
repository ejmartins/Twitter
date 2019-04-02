using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Usuario;
using Ejmartins.Twitter.Data.Repository;
using Ejmartins.Twitter.Data.Shared;
using Ejmartins.Twitter.Domain.Entities;
using Ejmartins.Twitter.Domain.Shared.Entities;

namespace Ejmartins.Twitter.ETL.Transformador
{
    public class Top5UsuarioTransformador : TransformadorBase<UsuarioResponse, Top5UsuarioRequest>, ITop5UsuarioTransformador
    {
        private IUsuarioService _serviceUsuario;
        private IDwService _serviceDw;

        public Top5UsuarioTransformador(IUsuarioService serviceUsuario_, IDwService serviceDw_)
        {
            _serviceUsuario = serviceUsuario_;
            _serviceDw = serviceDw_;
        }

        public override List<UsuarioResponse> ExtrairDadosOrigem()
        {
            return _serviceUsuario.GetAll().OrderByDescending(x => x.Seguidores).Take(5).ToList();
        }

        public override List<Top5UsuarioRequest> TransformarDados(List<UsuarioResponse> dados)
        {
           return Mapper.Map<List<UsuarioResponse>, List<Top5UsuarioRequest>>(dados);
        }

        public override void CarregarDados(List<Top5UsuarioRequest> dados)
        {
            _serviceDw.CarregarTop5Usuario(dados);
        }
    }
}
