using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    [Serializable]
    public class User : IUser
    {
        public string Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Email { get; set; }
        public virtual string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string FirstName { get { return FullName.Split(' ')[0]; } }
        public string LastName { get { return FullName.Split(' ')[1]; } }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new List<string>();
        }
        public IList<string> Roles { get; set; }
        public virtual void AddRole(string role)
        {
            this.Roles.Add(role);
        }
        public virtual void RemoveRole(string role)
        {
            Roles.Remove(role);
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
