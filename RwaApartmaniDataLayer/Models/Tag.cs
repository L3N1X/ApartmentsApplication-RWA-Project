using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    [Serializable]
    public class Tag
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   Id == tag.Id &&
                   Guid.Equals(tag.Guid);
        }

        public override int GetHashCode()
        {
            int hashCode = 712666156;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Guid.GetHashCode();
            return hashCode;
        }
    }
}
