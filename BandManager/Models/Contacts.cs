using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Contacts
    {
        public int ID { get; set; }

        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public string ManagerID { get; set; }
        public Manager manager { get; set; }
    }
}