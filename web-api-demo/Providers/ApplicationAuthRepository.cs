using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using web_api_demo.Models;

using web_api_demo.Providers.Context;

namespace web_api_demo.Providers
{
    public class ApplicationAuthRepository : IDisposable
    {
        private ApplicationDbAuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public ApplicationAuthRepository()
        {
            _ctx = new ApplicationDbAuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}