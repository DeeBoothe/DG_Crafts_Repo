using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DGCrafts.Models
{
    public class Document
    {
        [Key]
        public int DocID { get; set; }

        public string DocName { get; set; }

        public byte[] DocData { get; set; }

        public int ItemID { get; set; }

        [NotMapped]
        public string DocDataUrl { get; set; }

    }
}
