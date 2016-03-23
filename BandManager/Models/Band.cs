using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Band
    {
        public string ID { get; set; }

        [Display(Name = "Band Name")]
        public string Name { get; set; }

    }
}