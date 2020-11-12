using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DGCrafts.Models
{
    public class Announcement
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string AnnounceDescript { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
