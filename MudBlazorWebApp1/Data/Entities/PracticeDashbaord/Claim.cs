using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class Claim
    {
        public long ClaimId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid PracticeGuid { get; set; }

        public long? EncounterProcedureId { get; set; }

        public Guid PatientGuid { get; set; }
    }
}
