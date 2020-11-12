using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGCrafts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGCrafts.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartservice)
        {
            cart = cartservice;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
