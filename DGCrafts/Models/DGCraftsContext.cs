using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DGCrafts.Models
{
    public class DGCraftsContext : DbContext
    {

        public DGCraftsContext(DbContextOptions<DGCraftsContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ShippingInfo> Orders { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Document> Documents { get; set; }


    }
}
