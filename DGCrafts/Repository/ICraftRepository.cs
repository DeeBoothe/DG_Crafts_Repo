using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGCrafts.Models;

namespace DGCrafts.Repository
{
    public interface ICraftRepository
    {
       
        List<Item> GetItems();
        Item GetItem(int id);
        void SaveItem(Item item);
        Item DeleteItem(int itemId);

        Announcement GetAnnouncement(int id);
        List<Announcement> GetAnnouncements();
        void SaveAnnouncement(Announcement announce);
        Announcement DeleteAnnouncement(int announceId);

        void SaveImage(Image image);
        Image GetImage(int id);

        Document GetFile(int itemID);
        void SaveFile(Document doc);
    }
}
