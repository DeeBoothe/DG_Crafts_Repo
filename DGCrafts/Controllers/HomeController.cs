using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DGCrafts.Models;
using DGCrafts.Repository;

namespace DGCrafts.Controllers
{
    public class HomeController : Controller
    {
        private ICraftRepository repository;

        public HomeController(ICraftRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            var model = repository.GetItems();
            return View(model);
        }

        public IActionResult Item(int itemId)
        {
            var model = repository.GetItem(itemId);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
