using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OurApi.Controllers
{
    public class TodoController : BaseV1Controller
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Return), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public virtual object Get()
        {
            var list = new List<dynamic>();
            list.Add(new
            {
                UserId = Guid.NewGuid(),
                Name = "Devnot",
                SurName = "Dotnet Istanbul"
            });
            return Ok(new Return()
            {
                Success = true,
                Message = "Everthing is OK",
                Data = list
            });
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>This endpoint add a new Todo.</summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": "",
        ///        "title": "Todo Title",
        ///        "description" : "Desc" 
        ///        "isDone": false
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Return<TodoModel>), 200)]
        [ProducesResponseType(typeof(ReturnError), 400)]
        [ProducesResponseType(typeof(ReturnError), 500)]
        public object Post([FromBody]TodoModel value)
        {
            return BadRequest(new ReturnError()
            {
                Code = 400,
                Success = false,
                Message = "Your content is invalid.",
                Errors = new List<ReturnErrorModel>(){
                    new ReturnErrorModel(){
                        Key = "USERNAME",
                        Message = "User is invalid. Please use english chars."
                    }
                }
            });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
