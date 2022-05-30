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
            //    Console.WriteLine(apartment.Name);
            //}
            //var owners = repo.LoadApartmentOwners();
            //foreach (var owner in owners)
            //{
            //    Console.WriteLine(owner.Name);
            //}
            var reservations = repo.LoadApartmentReservations();
            foreach (var reservation in reservations)
            {
                var temp = repo.LoadApartmentReservationById(reservation.Id);
                Console.WriteLine($"Apartment: {temp.Apartment.Name} Username: {temp.User.UserName}");
            }
        }
    }
}
