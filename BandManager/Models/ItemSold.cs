﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class ItemSold
    {
        public int ID { get; set; }
        public int QuantitySold { get; set; }
        public decimal Price { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalSold { get; set; }
        public Event events { get; set; }
        public int EventID { get; set; }
        public List<Inventory> Inventories { get; set; }
        public int InventoryID { get; set; }
    }
}