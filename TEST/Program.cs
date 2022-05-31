using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Abstracts;
using RwaApartmaniDataLayer.Repositories.Implementations;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepo repo = new DBRepo();
            //var apartments = repo.LoadApartments();
            //foreach (var apartment in apartments)
            //{
            //    var statis = repo.LoadApartmentStatusById(apartment.StatusId);
            //    Console.WriteLine(statis.Name);
            //}
            //var owners = repo.LoadApartmentOwners();
            //foreach (var owner in owners)
            //{
            //    Console.WriteLine(owner.Name);
            //}
            //var reservations = repo.LoadApartmentReservations();
            //foreach (var reservation in reservations)
            //{
            //    var temp = repo.LoadApartmentReservationById(reservation.Id);
            //    Console.WriteLine($"Apartment: {temp.Apartment.Name} Username: {temp.User.UserName}");
            //}
            //var apartments = repo.LoadApartments(a => a.City.Name.Equals("Opatija"));
            //foreach (var apartment in apartments)
            //{
            //    Console.WriteLine(apartment.Name);
            //    foreach (var tag in apartment.Tags)
            //    {
            //        Console.WriteLine($"\t{tag.Name}");
            //    }
            //}
            //var reviews = repo.LoadApartmentReviews();
            //foreach (var review in reviews)
            //{
            //    var temp = repo.LoadApartmentReviewById(review.Id);
            //    Console.WriteLine($"Apartment: {temp.Apartment.Name} User: {temp.User.UserName} Review: {temp.Details} Stars: {temp.Stars}");
            //}
            //var tuples = repo.LoadTagsCounted();
            //foreach (var tuple in tuples)
            //{
            //    Console.WriteLine($"{tuple.Item1.Name}- ({tuple.Item2}) {(tuple.Item2.Equals(0) ? "- DELETE" : string.Empty)}");
            //}
        }
    }
}
