using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class EventInfoViewModel
    {
        public Event Events { get; set; }
        public Inventory Inventories { get; set; }
        public ItemSold ItemsSold { get; set; }
        public int QuantitySold { get; set; }
        public decimal Price { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalSold { get; set; }

    }
}