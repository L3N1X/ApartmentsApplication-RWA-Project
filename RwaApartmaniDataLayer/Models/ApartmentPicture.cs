using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    [Serializable]
    public class ApartmentPicture
    {
        private string path;
        private string base64Content;

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ApartmentId { get; set; }
        public string Path { get => path == string.Empty ? null : path; set => path = value; }
        public string Base64Content { get => base64Content == string.Empty ? null : base64Content; set => base64Content = value; }
        public string Name { get; set; }
        public bool IsRepresentative { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ApartmentPicture picture &&
                   Guid.Equals(picture.Guid);
        }

        public override int GetHashCode()
        {
            return -737073652 + Guid.GetHashCode();
        }
    }
}
