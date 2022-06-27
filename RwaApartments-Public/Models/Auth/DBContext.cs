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
        public IList<User> Users { get; set; }
        public void Dispose() { }

        public DBContext(IList<User> users)
        {
            Users = users;
        }
        public static DBContext Create()
        {
            var users = RepoFactory.GetRepoInstance().LoadUsers();
            return new DBContext(users);
        }
    }
}   