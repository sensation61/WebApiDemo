using Microsoft.AspNet.Identity.EntityFramework;
using web_api_demo.Models;

namespace web_api_demo.Providers.Context
{
    public class ApplicationDbAuthContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbAuthContext() : base("DefaultConnection", throwIfV1Schema: true)
        {
            
        }

        public static ApplicationDbAuthContext Create()
        {
            return new ApplicationDbAuthContext();
        }
    }
}