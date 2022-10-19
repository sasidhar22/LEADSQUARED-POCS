using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDynamo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDynamo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IAmazonDynamoDB dynamoDB { get; }

        public UsersController(IAmazonDynamoDB dynamoDB)
        {
            this.dynamoDB = dynamoDB;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<Test[]> Get()
        {
            var result = await dynamoDB.ScanAsync(new ScanRequest
            {
                TableName = "test"
            });
            if(result != null && result.Items != null)
            {
                var vals = new List<Test>();
                foreach(var item in result.Items)
                {
                    item.TryGetValue("username", out var uname);
                    item.TryGetValue("msq_quota", out var quota);
                    item.TryGetValue("msg_sent", out var sent);

                    vals.Add(new Test
                    {
                        username = uname?.S,
                        msq_quota = quota?.S,
                        msg_sent = sent?.S
                    });
                }
                return vals.ToArray();
            }
            return Array.Empty<Test>();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
