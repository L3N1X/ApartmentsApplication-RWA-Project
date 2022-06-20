using RwaApartmaniDataLayer.Repositories.Factories;
using RwaApartments_Public.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RwaApartments_Public.Controllers
{
    public class ApartmentsController : Controller
    {
        // GET: Apartments
        [HttpGet]
        public ActionResult BrowseApartments()
        {
            var model = new ApartmentsBrowserViewModel
            {
                Apartments = RepoFactory.GetRepoInstance().LoadApartments(a => true)
            };
            return View(model);
        }
    }
}