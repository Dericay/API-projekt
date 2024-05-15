using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class AppointmentAudit
    {
        [Key]
        public int AuditId { get; set; }
        public int AppointmentId { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Timestamp { get; set; }
        public int? CustomerId { get; set; }
        public int? CompanyId { get; set; }
    }
}
