using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class CustomerAppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CompanyName { get; set; }
    }
}
