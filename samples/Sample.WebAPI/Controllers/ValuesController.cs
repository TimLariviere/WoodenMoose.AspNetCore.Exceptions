using Microsoft.AspNetCore.Mvc;
using System.Net;
using WoodenMoose.AspNetCore.Exceptions;

namespace Sample.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (id < 0)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Id should be superior or equal to 0");

            if (id != 1)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Value with id '{id}' doesn't exist");

            return "value";
        }

        [HttpPost()]
        public int Post([FromBody] string data)
        {
            bool isAuthorized = !string.IsNullOrEmpty(data);
            if (!isAuthorized)
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, $"You are not authorized to create a new value");

            return 0;
        }
    }
}
