using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class Appointment
    {
        public long AppointmentId { get; set; }

        [Key]
        public Guid AppointmentGuid { get; set; }

        public Guid PatientGuid { get; set; }

        public Guid PracticeGuid { get; set; }

        public DateTime StartDate { get; set; }

        public string AppointmentConfirmationStatusCode { get; set; }

        public string AppointmentConfirmationStatusName { get; set; }

        public string AppointmentType { get; set; }

        public string AppointmentTypeDescription { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
