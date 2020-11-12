using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DGCrafts.Models
{
    public class Cart
    {


        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Item item, int quantity)
        {
            CartLine line = Lines
                .Where(i => i.Item.ItemID == item.ItemID)
                .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Item item) =>
            Lines.RemoveAll(p => p.Item.ItemID == item.ItemID);

        public decimal ComputeTotalValue() 
        {
           return (decimal)Lines.Sum(s => s.Item.UnitPrice * s.Quantity);
        }

        public virtual void Clear() => Lines.Clear();

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
    

