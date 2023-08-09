using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflowStarter.Models
{
    public class Broker
    {
        public string BrokerName { get; set; }
        public string BrokerNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string OfficeNumber { get; set; }

        public DateTime OfficeIssueDate { get; set; }
        public string OfficeActivity { get; set; }

        public string TransactionYear { get; set; }

        public string TransactionResidential { get; set; }
        public string TransactionCommercial { get; set; }
        public string TransactionTotal { get; set; }

        public string ProjectName { get; set; }
        public string ProjTransactions { get; set; }
        public string ProjectsTotal { get; set; }

        public string RankYear { get; set; }

        public string RankPoints { get; set; }

        public string Awards { get; set; }

        public  string BrokerMobile { get; set; }

        public string BrokerArea { get; set; }

    }

    public class Office
    {
        public  string OfficeName { get; set; } 
        
        public string officeNumber { get; set; }

        public string   licenseIssue { get; set; }

        public  string  licenseExpiry { get; set; }

        public  string  officeActivity { get; set; }

        public  string  officeBrokerCount { get; set; }

        public string officeRank { get; set; }

        public  string officeAward { get; set; }

    }
}
