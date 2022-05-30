using RwaApartmaniDataLayer.Repositories.Abstracts;
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
            IRepo repo = new AbstractDBRepo();
            var apartments = repo.LoadApartments();
            foreach (var apartment in apartments)
            {
                Console.WriteLine(apartment.Name);
            }
        }
    }
}
