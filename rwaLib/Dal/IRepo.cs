using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public interface IRepo
    {
        User AuthUser(string username, string password);
        IList<City> LoadCities();
        IList<User> LoadUsers();
        void SaveUser(User user);
        void AddUser(User user);
    }
}
