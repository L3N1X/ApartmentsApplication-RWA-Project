using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Factories;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.Auth
{
    public class DBContext : IDisposable
    {
        private DBContext(IList<User> users)
        {
            Users = users;
        }
        public IList<User> Users { get; set; }
        public void Dispose() { }
        public static DBContext Create()
        {
            //var users = RepoFactory.GetRepoInstance().LoadUsers();
            var users = new List<User>
            {
                new User()
                {
                    CreatedAt = DateTime.Now,
                    UserName = "lkruslin@racunarstvo.hr",
                    Email = "lkruslin@racunarstvo.hr",
                    Password = "1234",
                    Roles = new List<string>() { "Admin" }
                }
            };
            return new DBContext(users);
        }
    }
}   