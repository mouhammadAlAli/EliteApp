using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class ClaimAccounting
    {
        public decimal Amount { get; set; }  // NUMBER(38,4)

        public decimal ArAmount { get; set; }  // NUMBER(38,4)

        public long ClaimId { get; set; }

        public long ClaimTransactionId { get; set; }  // NUMBER(38,0)

        public string ClaimTransactionTypeCode { get; set; }

        public string ClaimTransactionTypeName { get; set; }

        public long? EncounterProcedureId { get; set; }

        public DateTime PostingDate { get; set; }

        public Guid PracticeGuid { get; set; }

        public Guid ProviderGuid { get; set; }
    }
}
