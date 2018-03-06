using Owin;
using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;

using web_api_demo.Providers;
using web_api_demo.Providers.Context;
using web_api_demo.Providers.Manager;

namespace web_api_demo
{
    public partial class Startup
    {
        public static string PublicClientId { get; private set; }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbAuthContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);


            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/auth/Token"), // Get token path
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin")
            };


            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Enable the application to use bearer tokens to authenticate users
            // app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}