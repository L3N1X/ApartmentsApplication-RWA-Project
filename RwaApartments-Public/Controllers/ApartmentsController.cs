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
        public ActionResult ShowAllApartments()
        {
            //return View();
            return Content("hihi");
        }
    }
}