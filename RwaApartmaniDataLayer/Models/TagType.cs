using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    public class TagType
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name{ get; set; }
        public string NameEng { get; set; }
    }
}
 