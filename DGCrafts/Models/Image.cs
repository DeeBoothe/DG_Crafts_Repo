using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGCrafts.Models
{
    //Got code from Lenore Montablano "SportsStore Uploading Pictures"
    public class Image
    {
        public int ID { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public int ItemID { get; set; }

        [NotMapped]
        public string ImageDataUrl { get; set; }
    }
}
