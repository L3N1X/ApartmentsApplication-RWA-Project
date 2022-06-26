using RwaApartmaniDataLayer.Models;
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
        [HttpGet]
        public ActionResult BrowseApartments()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadApartmentListPartialView(string search, int? cityId, string statusId, string filterCode)
        {
            Predicate<Apartment> avaliabilityFilter = (a => a.IsAvaliable);
            Predicate<Apartment> nameFilter = (a => true);
            Predicate<Apartment> cityFilter = (a => true);
            Predicate<Apartment> statusFilter = (a => true);

            if (search != null && search != string.Empty)
                nameFilter = (a => a.NameEng.Contains(search));
            if (cityId != null && cityId != 0)
                cityFilter = (a => a.CityId.Equals(cityId));
            if (statusId != null && statusId != string.Empty)
            {
                if ("all".Equals(statusId))
                    avaliabilityFilter = (a => true);
                else if ("unavaliable".Equals(statusId))
                    avaliabilityFilter = (a => !a.IsAvaliable);
            }

            List<Apartment> apartments = (List<Apartment>)RepoFactory.GetRepoInstance().LoadApartments(avaliabilityFilter, nameFilter, cityFilter, statusFilter);

            if (filterCode != null && filterCode != string.Empty)
            {
                if (Apartment.ComparisonDicitionary.Keys.Any(key => key.Equals(filterCode)))
                    apartments.Sort(Apartment.ComparisonDicitionary[filterCode]);
            }
            else
                apartments.Sort(Apartment.PriceLowToHighComparison);

            var model = new ApartmentListViewModel
            {
                Apartments = apartments
            };
            return PartialView("_ApartmentListView", model);
        }

        [HttpGet]
        public ActionResult DisplayApartmentInListView(int id)
        {
            var model = RepoFactory.GetRepoInstance().LoadApartmentById(id);
            return PartialView(viewName: "_ApartmentInListView", model: model);
        }

        [HttpGet]
        public ActionResult ViewApartment(int id)
        {
            var model = RepoFactory.GetRepoInstance().LoadApartmentById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitApartmentReview(ApartmentReview review)
        {
            RepoFactory.GetRepoInstance().InsertApartmentReview(review);
            return RedirectToAction($"/Apartments/ViewApartment{review.ApartmentId}");
        }
    }
}