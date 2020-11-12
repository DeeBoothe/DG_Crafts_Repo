using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DGCrafts.Models
{
    public class TestData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DGCraftsContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DGCraftsContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new Item 
                    { 
                        ItemName = "Scraf",
                        ItemDescription = "Colorful Scarf",
                        UnitPrice = 25,
                        AmtAvailable = 10

                    },

                     new Item
                     {
                         ItemName = "Pillow case",
                         ItemDescription = "Case for a pillow",
                         UnitPrice = 25,
                         AmtAvailable = 10

                     },

                      new Item
                      {
                          ItemName = "Throw blanket",
                          ItemDescription = "small blanket for coung warmth",
                          UnitPrice = 20,
                          AmtAvailable = 10

                      },

                       new Item
                       {
                           ItemName = "Sweater",
                           ItemDescription = "Grandpan varsity sweater",
                           UnitPrice = 50,
                           AmtAvailable = 10

                       },

                        new Item
                        {
                            ItemName = "Rug",
                            ItemDescription = "Colorful rugs",
                            UnitPrice = 35,
                            AmtAvailable = 10

                        }
                    );
            }
        }
    }
}
