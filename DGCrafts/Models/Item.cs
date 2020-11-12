using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGCrafts.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public double UnitPrice { get; set; }

        public int AmtAvailable { get; set; }

        
    }
}
