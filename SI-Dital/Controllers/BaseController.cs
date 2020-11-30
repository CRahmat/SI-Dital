using Microsoft.AspNet.Identity.Owin;
using SI_Dital;
using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Events.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected ApplicationSignInManager _signInManager;
        protected ApplicationUserManager _userManager;

        public BaseController()
        {

        }

        public BaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        //public async Task CheckHostRequest()
        //{
        //    var host = Request.Url.Host;
        //    var currentHost = await db.Hosts.Where(x => x.CustomDomain == host)
        //        .SingleOrDefaultAsync();
        //    if (currentHost != null)
        //    {
        //        ViewBag.LogoBright = currentHost.HeaderLogoBright;
        //        ViewBag.LogoDark = currentHost.HeaderLogoDark;
        //        ViewBag.Title = currentHost.CustomTitle;
        //        ViewBag.Descriptions = currentHost.CustomDescriptions;
        //        ViewBag.Image = currentHost.CustomImage;
        //        ViewBag.HostName = currentHost.FullName;
        //        ViewBag.HostTwitter = currentHost.TwitterUrl;
        //        ViewBag.HostFacebook = currentHost.FacebookUrl;
        //        ViewBag.HostInstagram = currentHost.InstagramUrl;
        //        ViewBag.HostWebsite = currentHost.WebsiteUrl;
        //        ViewBag.HostLinkedIn = currentHost.LinkedInUrl;
        //        ViewBag.HostYoutube = currentHost.YoutubeUrl;
        //        ViewBag.Banner1 = currentHost.Banner1;
        //        ViewBag.Banner2 = currentHost.Banner2;
        //        ViewBag.Banner3 = currentHost.Banner3;
        //        ViewBag.HomeTitle = currentHost.HomeTitle;
        //        ViewBag.HomeDescriptions = currentHost.HomeDescriptions;
        //        ViewBag.HostCustomDomain = currentHost.CustomDomain;
        //        ViewBag.HostEmail = currentHost.ContactUs;
        //        ViewBag.HostPhoneNumber = currentHost.PhoneNumber;
        //        ViewBag.HostAddress = currentHost.Address;
        //        ViewBag.HostAndroidUrl = currentHost.AndroidStoreUrl;
        //    }
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}