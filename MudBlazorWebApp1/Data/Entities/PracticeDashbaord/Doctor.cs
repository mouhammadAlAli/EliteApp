using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class Doctor
    {
        public long DoctorId { get; set; }

        [Key]
        public Guid DoctorGuid { get; set; }

        public Guid PracticeGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
