using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DGCrafts.Models
{
    public class ShippingInfo
    {
        [BindNever]
        [Key]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage ="Please enter a name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "please enter first address line")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

       
        public int Zipcode { get; set; }// change this to a string

        [BindNever]
        public bool Shipped { get; set; }

        
    }
}
