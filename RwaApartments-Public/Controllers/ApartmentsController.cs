﻿using RwaApartmaniDataLayer.Models;
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
        public ActionResult BrowseApartments(string search, int? cityId, int? statusId, string filterCode)
        {
            Predicate<Apartment> avaliabilityFilter = (a => a.IsAvaliable);
            Predicate<Apartment> nameFilter = (a => true);
            Predicate<Apartment> cityFilter = (a => true);
            Predicate<Apartment> statusFilter = (a => true);

            if(search != null && search != string.Empty)
                nameFilter = (a => a.NameEng.Contains(search));
            if (cityId != null && cityId != 0)
                cityFilter = (a => a.CityId.Equals(cityId));
            if (statusId != null && statusId != 0)
                statusFilter = (a => a.StatusId.Equals(statusId));

            List<Apartment> apartments = (List<Apartment>)RepoFactory.GetRepoInstance().LoadApartments(avaliabilityFilter, nameFilter, cityFilter, statusFilter);

            if (filterCode != null && filterCode != string.Empty)
            {
                if (Apartment.ComparisonDicitionary.Keys.Any(key => key.Equals(filterCode)))
                    apartments.Sort(Apartment.ComparisonDicitionary[filterCode]);
            }
            else
                apartments.Sort(Apartment.PriceLowToHighComparison);

            var model = new ApartmentsBrowserViewModel
            {
                Apartments = apartments
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewApartment(int id)
        {
            var model = RepoFactory.GetRepoInstance().LoadApartmentById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Hehe(int id)
        {
            return Content(id.ToString());
        }
    }
}