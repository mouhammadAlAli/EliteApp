using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class Encounter
    {
        [Key]
        public Guid EncounterGuid { get; set; }  // VARCHAR(36)

        public long EncounterId { get; set; }  // NUMBER(38,0)

        public Guid? AppointmentGuid { get; set; }

        public Guid ProviderGuid { get; set; }

        public Guid ServiceLocationGuid { get; set; }

        public Guid PatientGuid { get; set; }

        public Guid PracticeGuid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DateOfService { get; set; }

        public string EncounterStatusDescription { get; set; }
    }
}
