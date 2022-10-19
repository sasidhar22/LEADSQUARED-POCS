using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DynamoDB.PoC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamoDB.PoC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadTestController : ControllerBase
    {
        private readonly AmazonDynamoDBClient _DbClient;

        public LoadTestController(IOptions<DynamoDBConfig> dynamoConfig)
        {
            var Config = ValidateAndGetConfig(dynamoConfig);
            _DbClient = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(Config.AWSRegion)
            });
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<LoadTest>> Get()
        {

            DynamoDBContext Context = new DynamoDBContext(_DbClient);
            var dynamoOpConfig = new DynamoDBOperationConfig { Conversion = DynamoDBEntryConversion.V2 };
            var Result = await Context.ScanAsync<LoadTest>(null, dynamoOpConfig).GetRemainingAsync();

            return Result;
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

        private DynamoDBConfig ValidateAndGetConfig(IOptions<DynamoDBConfig> dynamoConfig)
        {
            if (dynamoConfig != null && dynamoConfig.Value != null && !string.IsNullOrEmpty(dynamoConfig.Value.AWSRegion))
            {
                return dynamoConfig.Value;
            }
            throw new Exception("Invalid Config");
        }
    }
}
