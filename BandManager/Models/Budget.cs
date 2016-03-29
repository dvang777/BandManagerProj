using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandManager.Models
{
    public class Budget
    {
        public int ID { get; set; }
        public decimal Total { get; set; }

        [Display(Name = "Transaction Type")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string TransactionDescription { get; set; }

        [Display (Name = "Amount")]
        public decimal TransactionAmount { get; set; }

        [Display (Name = "Date")]
        public DateTime TransActionDate { get; set; }
        public Band band { get; set; }
        public string BandID { get; set; }
    }
}