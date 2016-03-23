using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Event
    {
        public int ID { get; set; }
        public DateTime Begin {get; set; }
        public DateTime End { get; set;}
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Attendance { get; set; }
        public virtual Band band { get; set; }
        public string BandId { get; set; }
    }
}