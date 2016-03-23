using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Manager
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerID { get; set; }
        public virtual Band band { get; set; }
        public string BandId { get; set; }
    }
}