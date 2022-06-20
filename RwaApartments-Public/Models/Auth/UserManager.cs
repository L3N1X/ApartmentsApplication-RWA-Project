using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RwaApartmaniDataLayer.Models;
using RwaApartments_Public.Models.Auth;

namespace RwaApartments_Public.Models.Auth
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            var manager =
                new UserManager(
                    new UserStoreService<User>(context.Get<DBContext>().Users));
            manager.PasswordHasher = new PasswordHasher();

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            return manager;
        }

        public virtual async Task<IdentityResult> AddUserToRolesAsync(string userId, IList<string> roles)
        {
            var userRoleStore = (IUserRoleStore<User, string>)Store;

            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
                throw new InvalidOperationException("Invalid user Id");

            var userRoles = await userRoleStore.GetRolesAsync(user).ConfigureAwait(false);

            foreach (var role in roles.Where(role => !userRoles.Contains(role)))
                await userRoleStore.AddToRoleAsync(user, role).ConfigureAwait(false);

            return await UpdateAsync(user).ConfigureAwait(false);
        }

        public virtual async Task<IdentityResult> RemoveUserFromRolesAsync(string userId, IList<string> roles)
        {
            var userRoleStore = (IUserRoleStore<User, string>)Store;

            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
                throw new InvalidOperationException("Invalid user Id");

            var userRoles = await userRoleStore.GetRolesAsync(user).ConfigureAwait(false);

            foreach (var role in roles.Where(userRoles.Contains))
                await userRoleStore.RemoveFromRoleAsync(user, role).ConfigureAwait(false);

            return await UpdateAsync(user).ConfigureAwait(false);
        }
    }
}