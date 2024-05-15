using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    [Serializable]
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int companyId { get; set; }
        public Company company { get; set; }
    }
}
