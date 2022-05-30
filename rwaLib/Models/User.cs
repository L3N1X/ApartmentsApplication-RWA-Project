using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class User
    {
        private const char DELIMITER = '|';

        public int IDAuth { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public City City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName
        {
            get
            {
                return $"{FName} {LName}";
            }
        }
      
        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string fName, string lName, City city, string username, string password)
        {
            FName = fName;
            LName = lName;
            City = city;
            Username = username;
            Password = password;
        }
    }
}
