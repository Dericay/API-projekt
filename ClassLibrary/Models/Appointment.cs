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
        public int appoinmentID { get; set; }
        public int customerID { get; set; }
        public int companyID { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
