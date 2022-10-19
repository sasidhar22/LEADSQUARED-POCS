using ElasticSearch.PoC.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticSearch.PoC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadTestsController : ControllerBase
    {
        private readonly IElasticClient _elasticsearchClient;
        public LoadTestsController(IElasticClient elasticClient)
        {
            _elasticsearchClient = elasticClient;
        }

        // GET api/<LoadTestsController>/5
        [HttpGet("{id}")]
        public async Task<LoadTest> Get(string id)
        {
            var response = await _elasticsearchClient.SearchAsync<LoadTest>(search => search
                                                              .Index("LoadTest")
                                                              .Query(query => query.Term(term => term.leaseOwner, id) ||
                                                                       query.Match(match => match.Field(field => field.leaseOwner).Query(id))));
            return response?.Documents?.FirstOrDefault();
        }

        // POST api/<LoadTestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoadTestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoadTestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
