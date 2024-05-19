using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class AppointmentAuditDTO
    {
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
