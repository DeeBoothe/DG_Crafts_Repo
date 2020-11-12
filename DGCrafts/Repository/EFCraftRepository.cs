using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGCrafts.Models;

namespace DGCrafts.Repository
{
    public class EFCraftRepository : ICraftRepository
    {
        private DGCraftsContext context;

        public EFCraftRepository(DGCraftsContext ctx)
        {
            context = ctx;
        }

        

        public Announcement DeleteAnnouncement(int announceId)
        {
            Announcement dbEntry = context.Announcements
                .FirstOrDefault(c => c.ID == announceId);
            if (dbEntry != null)
            {
                context.Announcements.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public Item DeleteItem(int itemId)
        {
            Item dbEntry = context.Items
                .FirstOrDefault(c => c.ItemID == itemId);
            if (dbEntry != null)
            {
                context.Items.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public Announcement GetAnnouncement(int id)
        {
            return context.Announcements.FirstOrDefault(a => a.ID == id);
        }

        public List<Announcement> GetAnnouncements()
        {
            return context.Announcements.ToList();
        }

        public Document GetFile(int itemID)
        {
            Document doc = new Document();
            doc = context.Documents.FirstOrDefault(i => i.ItemID == itemID);
            if (doc == null) return doc;
            string docBase64Data = Convert.ToBase64String(doc.DocData);
            doc.DocDataUrl = string.Format("data:file/txt;base64,{0}", docBase64Data);
            return doc;
        }

        public Image GetImage(int itemId)
        {
            Image img = new Image();
            img = context.Images.FirstOrDefault(i => i.ItemID == itemId);
            if (img == null) return img;
            string imageBase64Data = Convert.ToBase64String(img.ImageData);
            img.ImageDataUrl = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            return img;
        }

        public Item GetItem(int id)
        {

           return context.Items.FirstOrDefault(c => c.ItemID == id);

        }

        public List<Item> GetItems()
        {
            return this.context.Items.ToList();
            
        }

        public void SaveAnnouncement(Announcement announce)
        {
            if (announce.ID == 0)
            {
                context.Announcements.Add(announce);
                context.SaveChanges();
            }
            else
            {
                Announcement dbEntry = context.Announcements
                    .FirstOrDefault(a => a.ID == announce.ID);
                if (dbEntry != null)
                {
                    dbEntry.Title = announce.Title;
                    dbEntry.AnnounceDescript = announce.AnnounceDescript;
                    dbEntry.StartDate = announce.StartDate;
                    dbEntry.EndDate = announce.EndDate;
                    context.SaveChanges();

                }
            }
        }

        public void SaveFile(Document doc)
        {
            Document dbEntry = context.Documents
             .FirstOrDefault(d => d.DocID == doc.DocID);
            if (dbEntry != null)
            {
                dbEntry.ItemID = doc.ItemID;
                dbEntry.DocData = doc.DocData;
                dbEntry.DocName = doc.DocName;

            }
            else
            {
                context.Documents.Add(doc);
            }

            context.SaveChanges();
        }

        public void SaveImage(Image image)
        {
            Image dbEntry = context.Images
               .FirstOrDefault(d => d.ID == image.ID);
            if (dbEntry != null)
            {
                dbEntry.ItemID = image.ItemID;
                dbEntry.ImageData = image.ImageData;
                dbEntry.ImageTitle = image.ImageTitle;

            }
            else
            {
                context.Images.Add(image);
            }

            context.SaveChanges();
        }

        public void SaveItem(Item item)
        {
            if (item.ItemID == 0)
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
            else
            {
                Item dbEntry = context.Items
                    .FirstOrDefault(p => p.ItemID == item.ItemID);
                if (dbEntry != null)
                {
                    dbEntry.ItemName = item.ItemName;
                    dbEntry.ItemDescription = item.ItemDescription;
                    dbEntry.UnitPrice = item.UnitPrice;
                    dbEntry.AmtAvailable = item.AmtAvailable;
                    context.Items.Update(dbEntry);
                    context.SaveChanges();

                }
            }
        }
    }
}
