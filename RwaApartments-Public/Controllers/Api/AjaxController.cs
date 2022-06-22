using RwaApartmaniDataLayer.Repositories.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RwaApartments_Public.Controllers.Api
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult GetApartmentNames(string term)
        {
            var allNames = RepoFactory.GetRepoInstance().LoadApartmentNames();
            var foundNames = allNames.Where(name => name.ToLower().Contains(term.ToLower()));
            return Json(foundNames, JsonRequestBehavior.AllowGet);
        }
    }
}