using Microsoft.ApplicationBlocks.Data;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public class DBRepo : IRepo
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static string APARTMENT_CS = ConfigurationManager.ConnectionStrings["apartments"].ConnectionString;

        public IList<Tags> LoadTags()
        {
            IList<Tags> tags = new List<Tags>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENT_CS, nameof(LoadTags)).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tags
                    {
                        Id = (int)row[nameof(Tags.Id)],
                        Name = row[nameof(Tags.Name)].ToString(),
                        CreatedAt = DateTime.Parse(row[nameof(Tags.CreatedAt)].ToString())
                    }
                );
            }

            return tags;
        }

        public object LoadApartmentsByTagId(int tagID)
        {
            IList<Tags> tags = new List<Tags>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENT_CS, nameof(LoadTags)).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tags
                    {
                        Id = (int)row[nameof(Tags.Id)],
                        Name = row[nameof(Tags.Name)].ToString(),
                        CreatedAt = DateTime.Parse(row[nameof(Tags.CreatedAt)].ToString())
                    }
                );
            }

            return tags;
        }

        public void AddUser(User user)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddUser), user.FName, user.LName, user.City.IDCity, user.Username, user.Password);
        }

        public User AuthUser(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0) return null;

            DataRow row = tblAuth.Rows[0];
            return new User
            {
                IDAuth = (int)row[nameof(User.IDAuth)],
                FName = row[nameof(User.FName)].ToString(),
                LName = row[nameof(User.LName)].ToString(),
                City = new City((int)row[nameof(City.IDCity)], row[nameof(City.Name)].ToString()),
                Username = row[nameof(User.Username)].ToString(),
                Password = row[nameof(User.Password)].ToString()
            };
        }

        public IList<City> LoadCities()
        {
            IList<City> cities = new List<City>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadCities)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                cities.Add(
                    new City
                    {
                        IDCity = (int)row[nameof(City.IDCity)],
                        Name = row[nameof(City.Name)].ToString(),
                    }
                );
            }

            return cities;
        }

        public IList<User> LoadUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        IDAuth = (int)row[nameof(User.IDAuth)],
                        FName = row[nameof(User.FName)].ToString(),
                        LName = row[nameof(User.LName)].ToString(),
                        City = new City((int)row[nameof(City.IDCity)], row[nameof(City.Name)].ToString()),
                        Username = row[nameof(User.Username)].ToString(),
                        Password = row[nameof(User.Password)].ToString()
                    }
                );
            }

            return users;
        }

        public void SaveUser(User user)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SaveUser), user.FName, user.LName, user.Username, user.IDAuth);
        }
    }
}
