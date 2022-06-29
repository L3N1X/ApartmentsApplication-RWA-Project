using Microsoft.AspNet.Identity.Owin;
using Recaptcha.Web.Mvc;
using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Factories;
using RwaApartments_Public.Models.Auth;
using RwaApartments_Public.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RwaApartments_Public.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private UserManager _authManager;
        private SignInManager _signInManager;

        public SignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<SignInManager>(); }
            set { _signInManager = value; }
        }
        public UserManager AuthManager
        {
            get { return _authManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            set { _authManager = value; }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            var user = await AuthManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                await SignInManager.SignInAsync(user, true, model.RememberMe);
                ViewBag.username = user.UserName;
                return RedirectToAction(actionName: "BrowseApartments", controllerName: "Apartments");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult BrowseApartments()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult LoadApartmentReviewsListView(int apartmentId)
        {
            var reviews = RepoFactory.GetRepoInstance().LoadApartmentReviewsByApartmentId(apartmentId);
            return PartialView("_ReviewListView", new ApartmentReviewListModel { Reviews = reviews.Reverse()});
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult DisplayApartmentInListView(int id)
        {
            var model = RepoFactory.GetRepoInstance().LoadApartmentById(id);
            return PartialView(viewName: "_ApartmentInListView", model: model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ViewApartment(int apartmentId)
        {
            var loggedUser = await AuthManager.FindByNameAsync(User.Identity.Name);
            bool showReviewForm = true;
            if (loggedUser == null)
            {
                loggedUser = new User { Id = null };
                showReviewForm = false;
            }
            var model = new ViewApartmentViewModel
            {
                Apartment = RepoFactory.GetRepoInstance().LoadApartmentById(apartmentId),
                ShowReviewForm = showReviewForm
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ViewApartment(ViewApartmentViewModel model)
        {
            return View(model);
        } 

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubmitApartmentReview(ApartmentReview review)
        {
            RepoFactory.GetRepoInstance().InsertApartmentReview(review);
            return new EmptyResult();
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public async Task<PartialViewResult> LoadContactReservationPartial(int apartmentId)
        {
            var loggedUser = await AuthManager.FindByNameAsync(User.Identity.Name);
            if (loggedUser is null)
                loggedUser = new User { Id = null };
            ContactReservationViewModel contactViewModel = new ContactReservationViewModel
            {
                User = loggedUser,
                ApartmentId = apartmentId,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };
            return PartialView("_ContactReservation", contactViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubmitApartmentReservation(ContactReservationViewModel model)
        {
            var firstname = model.User.FirstName;
            var recaptchaHelper = this.GetRecaptchaVerificationHelper(secretKey: "6Ld0Ya0gAAAAAP0oJWaYw1iafuD_aEXB_GUn7iGS");
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError(
                "",
                "Captcha answer cannot be empty.");
                return RedirectToAction(controllerName: "Apartments", actionName: "ViewApartment", routeValues: new { id = model.ApartmentId });
                //return View(model);
            }
            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (!recaptchaResult.Success)
            {
                ModelState.AddModelError(
                "",
                "Incorrect captcha answer.");
                //return View(model);
                return RedirectToAction(controllerName: "Apartments", actionName: "ViewApartment", routeValues: new { id = model.ApartmentId });
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction(controllerName: "Apartments", actionName: "ViewApartment", routeValues: new { id = model.ApartmentId });
            }

            return RedirectToAction(controllerName: "Apartments", actionName: "ViewApartment", routeValues: new { id = model.ApartmentId });
        }
    }
}