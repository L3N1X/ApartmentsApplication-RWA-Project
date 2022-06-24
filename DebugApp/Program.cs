using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Factories;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepo repo = RepoFactory.GetRepoInstance();
            var apartments = repo.LoadApartments(a => true);
            foreach (var apartment in apartments)
            {
                Console.WriteLine(apartment.Stars);
            }
        }
    }
}
