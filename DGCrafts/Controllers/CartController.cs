using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGCrafts.Repository;
using DGCrafts.Models;
using DGCrafts.Models.ViewModels;

namespace DGCrafts.Controllers
{
    public class CartController : Controller
    {
        private ICraftRepository repository;
        private Cart _Cart { get; set; }
        

        public CartController(ICraftRepository repo, Cart cartservice)
        {
            repository = repo;
            _Cart = cartservice;

            
        }

        public IActionResult Index(string returnUrl)
        { 
            return View(new CartIndexViewModel
            { 
                Cart = _Cart,
                ReturnUrl = returnUrl
            });
        }




        public RedirectToActionResult AddToCart(int itemId, int quantity, string returnUrl)// How do you know how much the Customer has order with Amt Available?
        {
            Item item = repository.GetItems()
                .FirstOrDefault(p => p.ItemID == itemId);
            if (item != null)
            {
                _Cart.AddItem(item, quantity);
                var newAmt = repository.GetItem(item.ItemID).AmtAvailable - quantity;

                Item updateItem = new Item
                {
                    ItemID = item.ItemID,
                    ItemDescription = item.ItemDescription,
                    ItemName = item.ItemName,
                    AmtAvailable = newAmt,
                    UnitPrice = item.UnitPrice
                };

                repository.SaveItem(updateItem);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //public RedirectToActionResult AddToCart(Item cItem, string returnUrl)
        //{
        //    Item item = repository.GetItems()
        //        .FirstOrDefault(p => p.ItemID == cItem.ItemID);
        //    if (item != null)
        //    {
        //        _Cart.AddItem(cItem, cItem.AmtAvailable);
        //    }

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        
        public RedirectToActionResult Remove(int itemId, int quantity, string returnUrl)
        {
            Item item = repository.GetItems()
               .FirstOrDefault(p => p.ItemID == itemId);
            if (item != null)
            {
                _Cart.RemoveLine(item);
                var newAmt = repository.GetItem(item.ItemID).AmtAvailable + quantity;

                Item updateItem = new Item
                {
                    ItemID = item.ItemID,
                    ItemDescription = item.ItemDescription,
                    ItemName = item.ItemName,
                    AmtAvailable = newAmt,
                    UnitPrice = item.UnitPrice
                };

                repository.SaveItem(updateItem);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
