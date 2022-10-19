using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoDB.PoC
{
    public class DynamoDBConfig
    {
        public string ConverseTenantLevelConfigTableName { get; set; }
        public string AWSRegion { get; set; }
        public string ConverseUserLevelConfigTableName { get; set; }
        public string ConverseTenantLicensingAuditTableName { get; set; }
        public string ConverseSupportGroupTableName { get; set; }
    }
}
