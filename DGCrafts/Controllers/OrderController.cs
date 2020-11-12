using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGCrafts.Models;
using DGCrafts.Repository;

namespace DGCrafts.Controllers
{
    public class OrderController : Controller
    {

        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartservice)
        {
            repository = repoService;
            cart = cartservice;
        }

        public ViewResult ShippingForm()
        {
            return View(new ShippingInfo());
        }

        [HttpPost]
        public IActionResult ShippingForm(ShippingInfo order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToAction(nameof(Confirmation));
            }
            else
            {
                return View(order);
            }
        }



        public IActionResult Confirmation()
        {
            cart.Clear();
            return View();
        }
    }
}
