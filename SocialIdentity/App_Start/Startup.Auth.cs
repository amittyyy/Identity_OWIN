using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Owin.Security.Providers.GitHub;
using SocialIdentity.Models;

namespace SocialIdentity
{
    public partial class Startup
    {
        
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));


            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            app.UseGitHubAuthentication(
                clientId: "936aab00473a81993c5f",
                clientSecret: "6e9513efc97c22428e496597d2460b4df3b0a5d1");

            app.UseMicrosoftAccountAuthentication(
                clientId: "903e2be0-ee06-4517-b22a-a7f3c134b52a",
                clientSecret: "aeliWNX859;;pvlFXNP02;:");

            app.UseTwitterAuthentication(
               consumerKey: "fQzl0JOncd88EULfZiKZcOsg2",
               consumerSecret: "gmv8lIM5Y9yqfbNfjTTiBDsmXUe4L5XFqTlnpi4GC7px8evf5F");

            app.UseFacebookAuthentication(
               appId: "1786762051372127",
               appSecret: "36442c34d37142e212a22a75d17695a9");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "163184958308-geg61b9bedm59ce84p5fbebnq0k1tl20.apps.googleusercontent.com",
                ClientSecret = "2rwYxSag_I5GEu0WDLUWzkQg"
            });
        }
    }
}