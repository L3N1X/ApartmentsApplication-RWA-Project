using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Utilities
{
    public static class Parsers
    {
        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }
        public static int? TryParseInt(string text)
        {
            int val;
            if(int.TryParse(text, out val))
                return val;
            return null;
        }
    }
}
