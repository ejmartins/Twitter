using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ejmartins.Twitter.Application.Tweet;

namespace Ejmartins.Twitter.API.Controllers
{
    public class TweetController : ApiController
    {
        private readonly ITweetService _service;
        public TweetController(ITweetService service)
        {
            _service = service;
        }
        [HttpPost]
        //[Authorize]
        public int Create([FromBody] TweetRequest request)
        {
            return _service.Create(request);
        }

        [HttpGet]
        //[Authorize]
        public List<TweetResponse> GetAll()
        {
            return _service.GetAll();
        }
    }
}
