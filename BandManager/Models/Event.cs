using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Event
    {
        public int ID { get; set; }

        [Display(Name = "Event Start")]
        public DateTime Begin {get; set; }

        [Display(Name = "Event End")]
        public DateTime End { get; set;}
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Attendance { get; set; }

        [Display (Name ="Total Items Sold")]
        public int TotalItemSold { get; set; }

        [Display(Name = "Revenue")]
        public decimal TotalRevenue { get; set; }
        public virtual Band band { get; set; }
        public string BandId { get; set; }
    }
}