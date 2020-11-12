using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGCrafts.Models;
using DGCrafts.Repository;
using System.IO;

namespace DGCrafts.Controllers
{
    public class AdminController : Controller
    {

        private ICraftRepository repository;

        private IOrderRepository orderRepository;
     

        public AdminController(ICraftRepository repo, IOrderRepository oRepo)
        {
            repository = repo;
            orderRepository = oRepo;
        }

        public IActionResult Index()
        {
            var model = repository.GetItems();
            return View(model);
        }





        #region Announcements
        public IActionResult Announcements()
        {
            var model = repository.GetAnnouncements();
            return View(model);
        }

        public IActionResult EditAnnouncement(int id)
        {
            var model = repository.GetAnnouncement(id);
            return View("MakeAnnouncement", model);
           
        }

        public IActionResult MakeAnnouncement()
        {
            var model = new Announcement();
            return View(model);
        }

        [HttpPost]
        public IActionResult MakeAnnouncement(Announcement announce)
        {
            repository.SaveAnnouncement(announce);
            return RedirectToAction("Announcements");
        }

        public IActionResult RemoveAnnouncement(int id)
        {
            var model = repository.GetAnnouncement(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            repository.DeleteAnnouncement(id);
            return RedirectToAction("Announcements");
        }
        #endregion



        #region EditStore / Items
        public IActionResult EditStore()
        {
            var model = repository.GetItems();
         

            return View(model);
        }

        public IActionResult Create()
         {
             return View("Edit", new Item());
         }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            repository.SaveItem(item);
            UploadImage(item);
            return RedirectToAction("EditStore");
        }

        public IActionResult Edit(int itemId)
        {
            var model = repository.GetItem(itemId);
            return View(model);
        }

        public  IActionResult Delete(int itemId)
        {
            var model = repository.GetItem(itemId);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteItem(int itemId)
        {
            repository.DeleteItem(itemId);
            return RedirectToAction("EditStore");
        }
        #endregion


        public IActionResult Files(int itemID)
        {
            var model = repository.GetItem(itemID);
            return View(model);
        }

        [HttpPost]
        public IActionResult Files(Document doc)
        {
            UploadFile(doc);
            return View();
        }



        public IActionResult Orders()
        {
            var model = orderRepository.GetOrders();
            return View(model);
        }


        public void UploadFile(Document doc)
        {
            if (doc.ItemID > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    var document = new Document { ItemID = doc.ItemID, DocName = file.FileName };

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        doc.DocData = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }

                    repository.SaveFile(doc);
                }

                TempData["message"] = "File(s) stored in  database!";
            }
            else
            {
                TempData["message"] = "Cannot add Files to a non existent product!";
            }


        }





        public void UploadImage(Item item)
        {
            if (item.ItemID > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    var img = new Image { ItemID = item.ItemID, ImageTitle = file.FileName };

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        img.ImageData = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }

                    repository.SaveImage(img);
                }

                TempData["message"] = "Image(s) stored in  database!";
            }
            else
            {
                TempData["message"] = "Cannot add images to a non existent product!";
            }

            
        }
    }
}
