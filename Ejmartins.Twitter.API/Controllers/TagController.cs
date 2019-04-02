using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ejmartins.Twitter.Application.Tag;

namespace Ejmartins.Twitter.API.Controllers
{
    public class TagController : ApiController
    {
        private readonly ITagService _service;
        public TagController(ITagService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize]
        public int Create([FromBody] TagRequest request)
        {
            return _service.Create(request);
        }

        [HttpGet]
        //[Authorize]
        public List<TagResponse> GetAll()
        {
            return _service.GetAll();
        }
    }
}
