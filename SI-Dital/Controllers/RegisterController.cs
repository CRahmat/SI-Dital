using Events.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.Controllers
{
    public class RegisterController : BaseController
    {
        // GET: Register
        public async Task<ActionResult> RegisterCitizens()
        {
            return View();
        }
        public async Task<ActionResult> RegisterAdmin()
        {
            return View();
        }
    }
}