using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGCrafts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DGCrafts.Components
{
    public class AnnouncementCardViewComponent : ViewComponent
    {
        private ICraftRepository repository;

        public AnnouncementCardViewComponent(ICraftRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(repository.GetAnnouncements());
        }
    }
}
