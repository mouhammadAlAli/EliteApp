using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class ClaimTransaction
    {
        public long ClaimTransactionId { get; set; }

        public long ClaimId { get; set; }

        public string ClaimTransactionTypeCode { get; set; }
        public string ClaimTransactionTypeName { get; set; }

        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime PostingDate { get; set; }

    }
}
