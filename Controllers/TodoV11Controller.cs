using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OurApi.Controllers
{
    [Route("v1.1/todo")]
    public class TodoV11Controller : TodoController
    {
        [HttpGet]
        [Obsolete]
        public override object Get()
        {
            throw new Exception("This endpoint is deprecated.");
        }
    }
}