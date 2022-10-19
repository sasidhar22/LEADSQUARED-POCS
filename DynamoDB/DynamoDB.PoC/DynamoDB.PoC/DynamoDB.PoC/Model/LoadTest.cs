using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace DynamoDB.PoC.Model
{
    [DynamoDBTable("logstash-dev-workflowtriggerdatalog-mum-loadtest")]
    public class LoadTest
    {
        [DynamoDBHashKey]
        public string leaseKey { get; set; }
        public string checkpoint { get; set; }
        public int checkpointSubSequenceNumber { get; set; }
        public int leaseCounter { get; set; }
        public string leaseOwner { get; set; }
        public int ownerSwitchesSinceCheckpoint { get; set; }
    }
}

