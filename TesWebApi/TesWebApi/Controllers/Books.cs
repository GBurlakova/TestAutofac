using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TesWebApi.Models;
using TesWebApi.Services;

namespace TesWebApi.Controllers
{
    public class BooksController: ApiController
    {
        private readonly IService service;

        public BooksController(IService service)
        {
            this.service = service;
        }

        public IHttpActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(service.GetNumber());
        }
    }
}