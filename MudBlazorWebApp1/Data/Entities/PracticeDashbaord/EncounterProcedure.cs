using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class EncounterProcedure
    {
        public long EncounterProcedureId { get; set; }

        public Guid EncounterGuid { get; set; }

        public Guid PracticeGuid { get; set; }

        public Guid ProviderGuid { get; set; }  // VARCHAR(36)

        public DateTime CreatedDate { get; set; }
    }
}
