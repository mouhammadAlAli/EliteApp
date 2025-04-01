using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDashboard.Data.NewEntities
{
    public class ServiceLocation
    {
        public string Name { get; set; }

        public Guid PracticeGuid { get; set; }

        [Key]
        public Guid ServiceLocationGuid { get; set; }

        public long ServiceLocationId { get; set; }
    }
}
