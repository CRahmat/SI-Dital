using SI_Dital.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var documentTypes = await db.DocumentTypes.Where(x => x.IsDeleted != true).ToListAsync();
            return View(documentTypes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendRequestDocument(string Description, string DocumentType)
        {
            if(Description == null)
            {
                return Json("NULL", JsonRequestBehavior.AllowGet);
            }
            else if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var documentType = await db.DocumentTypes.Where(x => x.Permalink == DocumentType).SingleOrDefaultAsync();
                    var addRequestDocument = new Models.Document
                    {
                        IdDocument = Guid.NewGuid().ToString(),
                        Descriptions = Description,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow,
                        Status = Models.Status.Pending,
                        DocumentGroup = documentType,
                        IsDeleted = false
                    };
                    try
                    {
                        db.Documents.Add(addRequestDocument);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return Json("OK", JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
                else
                {
                    return Json("NOTLOGIN", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("KO", JsonRequestBehavior.AllowGet);
        }
    }
}