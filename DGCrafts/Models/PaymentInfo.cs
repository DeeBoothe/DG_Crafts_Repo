using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGCrafts.Models
{
    public class PaymentInfo
    {
        public int CardNumber { get; set; }

        public string NameOnCard { get; set; }

        public int CVC { get; set; }

        public string CustEmail {get; set;}
    }
}
