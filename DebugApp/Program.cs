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
            //var users = RepoFactory.GetRepoInstance().LoadUsers();
            //foreach (var user in users)
            //{
            //    Console.WriteLine(user.PasswordHash);
            //}
            //Console.WriteLine(SHA512("123"));
            User user = RepoFactory.GetRepoInstance().LoadUserById(1);
            Console.WriteLine(user.UserName);
        }
        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
