using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ejmartins.Twitter.Application.Dw;
using Ejmartins.Twitter.Application.Tag;

namespace Ejmartins.Twitter.API.Controllers
{
    public class DwController : ApiController
    {
        private readonly IDwService _service;
        public DwController(IDwService service)
        {
            _service = service;
        }

        public DwController()
        {

        }
        [HttpGet]
        public string Teste()
        {
            return "teste";
        }


        [HttpPost]
        public void CarregarPostagemPorDia([FromBody]List<PostagemPorDiaRequest> request)
        {
            _service.CarregarPostagemPorDia(request);
        }
        [HttpPost]
        public void CarregarPostagemPorHashTag([FromBody]List<PostagemPorHashTagRequest> request)
        {
            _service.CarregarPostagemPorHashTag(request);
        }
        [HttpPost]
        public void CarregarTop5Usuario([FromBody]List<Top5UsuarioRequest> request)
        {
            _service.CarregarTop5Usuario(request);
        }
        [HttpGet]
        public List<PostagemPorDiaResponse> ListarPostagemPorDia()
        {
            return _service.ListarPostagemPorDia();
        }
        [HttpGet]
        public List<PostagemPorHashTagResponse> ListarPostagemPorHashTag()
        {
            return _service.ListarPostagemPorHashTag();
        }

        [HttpGet]
        public List<Top5UsuarioResponse> ListarTop5Usuario()
        {
            return _service.ListarTop5Usuario();
        }
    }
}
