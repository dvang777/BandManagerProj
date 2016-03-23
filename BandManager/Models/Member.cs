using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BandID { get; set; }
        public virtual Band band { get; set; }

    }
}