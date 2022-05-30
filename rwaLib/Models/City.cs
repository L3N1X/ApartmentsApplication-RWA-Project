using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class City
    {
        public City()
        {

        }

        public City(int iDCity, string name)
        {
            IDCity = iDCity;
            Name = name;
        }

        public int IDCity { get; set; }
        public string Name { get; set; }


    }
}
