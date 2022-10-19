using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // GET: api/<HelloController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> wish = new List<string>
            {
                "Hello ",
                "World!"
            };
            return wish;
        }

        // GET api/<HelloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HelloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HelloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HelloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
