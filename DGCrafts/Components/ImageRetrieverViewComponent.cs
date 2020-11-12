using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGCrafts.Repository;


namespace DGCrafts.Components
{
    public class ImageRetrieverViewComponent : ViewComponent
    {
        private ICraftRepository repository;

        public ImageRetrieverViewComponent(ICraftRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(int itemId)
        {
            return View(repository.GetImage(itemId));
        }
    }
}
