using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Company
    {
        [Key]
        public int companyID { get; set; }
        [Required]
        public string companyName { get; set; }
        public string Adress {  get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
    }
}
