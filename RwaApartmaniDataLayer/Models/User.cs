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

        [Required(ErrorMessage = "E-mail address is required")]
        [EmailAddress(ErrorMessage = "E-mail address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(maximumLength: 16, ErrorMessage = "Password must be between 6 and 16 characters long ", MinimumLength = 6)]
        public string Password 
        {
            get { return this.PasswordHash; }
            set { this.PasswordHash = Utils.Cryptography.SHA512(value); }
        }
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get { return UserName.Split(' ')[0]; } }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get { return UserName.Split(' ')[1]; } }
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
