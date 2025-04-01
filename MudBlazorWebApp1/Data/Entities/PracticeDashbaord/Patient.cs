using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class Patient
    {
        [Key]
        public Guid PatientGuid { get; set; }  // VARCHAR(36)

        public long PatientId { get; set; }  // NUMBER(38,0)

        public Guid PracticeGuid { get; set; }

        public DateTime? DOB { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? MobilePhone { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
