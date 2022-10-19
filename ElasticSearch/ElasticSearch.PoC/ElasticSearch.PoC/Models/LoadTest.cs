using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ElasticSearch.PoC.Models
{
    public class LoadTest
    {
        public string leaseKey { get; set; }
        public string leaseOwner { get; set; }
        public int leaseCounter { get; set; }
    }
}


