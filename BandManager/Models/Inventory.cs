using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        [Display (Name = "Ordered YTD")]
        public int OrderedYTD { get; set; }
        public int Quantity { get; set; }
        public int QuantityIncoming { get; set; }
        public int SoldQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalSold { get; set; }
        public virtual Band band { get; set; }
        public string BandId { get; set; }

    }
}