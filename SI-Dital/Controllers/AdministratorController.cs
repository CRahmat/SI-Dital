using Events.Controllers;
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
    public class AdministratorController : BaseController
    {
        // GET: Administrator
        public async Task<ActionResult> Dashboard()
        {
            return View();
        }
/*-------------------------------------------------------------------*/
        public async Task<ActionResult> RT()
        {
            var RT = await db.RT.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
            if (RT != null)
            {
                return View(RT);
            }
            return View();
        }
        public async Task<ActionResult> DetailRT(string id)
        {
            var RT = await db.RT.Where(x => x.IdRT == id && x.IsActive == true).SingleOrDefaultAsync();
            if (RT != null)
            {
                return View(RT);
            }
            return View();
        }
        public async Task<ActionResult> AddRT()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRT(ViewModels.AddRT newRT)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addRT = new Models.RT
                    {
                        IdRT = newRT.IdRT,
                        Name = newRT.Name,
                        Chairman = newRT.Chairman,
                        IsActive = true,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.RT.Add(addRT);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RT");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditRT(string id)
        {
            var RT = await db.RT.Where(x => x.IdRT == id && x.IsActive == true).SingleOrDefaultAsync();
            if (RT != null)
            {
                return View(RT);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditRT(ViewModels.AddRT updateRT)
        {
            if (updateRT != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editRT = new Models.RT
                    {
                        IdRT = updateRT.IdRT,
                        Name = updateRT.Name,
                        Chairman = updateRT.Chairman,
                        IsActive = true,
                        UpdatedBy = currentUser,
                        Updated = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editRT).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RT");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteRT(ViewModels.EditRT updateRT)
        {
            if (updateRT != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editRT = new Models.RT
                    {
                        IsDeleted = true,
                        IsActive = false,
                        DeletedBy = currentUser,
                        Deleted = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editRT).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RT");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/
        public async Task<ActionResult> RW()
        {
            var RW = await db.RW.Where(x => x.IsActive == true).ToListAsync();
            if (RW != null)
            {
                return View(RW);
            }
            return View();
        }
        public async Task<ActionResult> DetailRW(string id)
        {
            var RW = await db.RW.Where(x => x.IdRW == id && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync();
            if (RW != null)
            {
                return View(RW);
            }
            return View();
        }
        public async Task<ActionResult> AddRW()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddRW(ViewModels.AddRW newRW)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addRW = new Models.RW
                    {
                        IdRW = newRW.IdRW,
                        Name = newRW.Name,
                        Chairman = newRW.Chairman,
                        IsActive = true,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.RW.Add(addRW);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RW");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditRW(string id)
        {
            var RW = await db.RW.Where(x => x.IdRW == id && x.IsActive == true).SingleOrDefaultAsync();
            if (RW != null)
            {
                return View(RW);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditRW(ViewModels.AddRW updateRW)
        {
            if (updateRW != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editRW = new Models.RW
                    {
                        IdRW = updateRW.IdRW,
                        Name = updateRW.Name,
                        Chairman = updateRW.Chairman,
                        IsActive = true,
                        UpdatedBy = currentUser,
                        Updated = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editRW).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RW");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteRW(ViewModels.EditRW updateRW)
        {
            if (updateRW != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editRW = new Models.RW
                    {
                        IsDeleted = true,
                        IsActive = false,
                        DeletedBy = currentUser,
                        Deleted = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editRW).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("RW");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/
        public async Task<ActionResult> DocumentType()
        {
            var documentType = await db.DocumentTypes.Where(x => x.IsDeleted == false).ToListAsync();
            if (documentType != null)
            {
                return View(documentType);
            }
            return View();
        }
        public async Task<ActionResult> DetailDocumentType(string id)
        {
            var documentType = await db.DocumentTypes.Where(x => x.Permalink == id && x.IsDeleted == true).SingleOrDefaultAsync();
            if (documentType != null)
            {
                return View(documentType);
            }
            return View();
        }
        public async Task<ActionResult> AddDocumentType()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDocumentType(ViewModels.AddDocumentType newDocumentType)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addDocumentType = new Models.DocumentGroup
                    {
                        Permalink = newDocumentType.IdDocumentType,
                        Title = newDocumentType.Name,
                        Order = newDocumentType.Order,
                        IsDeleted = false,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.DocumentTypes.Add(addDocumentType);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("DocumentType");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditDocumentType(string permalink)
        {
            var documentType = await db.DocumentTypes.Where(x => x.Permalink == permalink && x.IsDeleted == false).SingleOrDefaultAsync();
            if (documentType != null)
            {
                return View(documentType);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditDocumentType(ViewModels.AddDocumentType updateDocumentType)
        {
            if (updateDocumentType != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editDocumentType = new Models.DocumentGroup
                    {
                        Permalink = updateDocumentType.IdDocumentType,
                        Title = updateDocumentType.Name,
                        IsDeleted = false,
                        UpdatedBy = currentUser,
                        Updated = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editDocumentType).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("DocumentType");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteDocumentType(ViewModels.EditDocumentType updateDocumentType)
        {
            if (updateDocumentType != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var documentType = new Models.DocumentGroup
                    {
                        IsDeleted = true,
                        DeletedBy = currentUser,
                        Deleted = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(documentType).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("DocumentType");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/
        public async Task<ActionResult> Hamlet()
        {
            var hamlet = await db.Hamlets.Where(x => x.IsActive == true).ToListAsync();
            if (hamlet != null)
            {
                return View(hamlet);
            }
            return View();
        }
        public async Task<ActionResult> DetailHamlet(string id)
        {
            var hamlet = await db.Hamlets.Where(x => x.IdHamlet == id && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync();
            if (hamlet != null)
            {
                return View(hamlet);
            }
            return View();
        }
        public async Task<ActionResult> AddHamlet()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddHamlet(ViewModels.AddHamlet newHamlet)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addHamlet = new Models.Hamlet
                    {
                        IdHamlet = newHamlet.IdHamlet,
                        Name = newHamlet.Name,
                        Chairman = newHamlet.Chairman,
                        IsActive = true,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Hamlets.Add(addHamlet);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Hamlet");

                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditHamlet(string id)
        {
            var hamlet = await db.Hamlets.Where(x => x.IdHamlet == id && x.IsActive == true).SingleOrDefaultAsync();
            if (hamlet != null)
            {
                return View(hamlet);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditHamlet(ViewModels.AddHamlet updateHamlet)
        {
            if (updateHamlet != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editHamlet = new Models.Hamlet
                    {
                        IdHamlet = updateHamlet.IdHamlet,
                        Name = updateHamlet.Name,
                        Chairman = updateHamlet.Chairman,
                        IsActive = true,
                        UpdatedBy = currentUser,
                        Updated = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editHamlet).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Hamlet");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteHamlet(ViewModels.EditHamlet updateHamlet)
        {
            if (updateHamlet != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var hamlet = new Models.Hamlet
                    {
                        IsDeleted = true,
                        IsActive = false,
                        DeletedBy = currentUser,
                        Deleted = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(hamlet).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Hamlet");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/
        public async Task<ActionResult> Job()
        {
            var job = await db.Jobs.Where(x => x.IsDeleted == false).ToListAsync();
            if (job != null)
            {
                return View(job);
            }
            return View();
        }
        public async Task<ActionResult> DetailJob(int id)
        {
            var job = await db.Jobs.Where(x => x.IdJob == id && x.IsDeleted == false).SingleOrDefaultAsync();
            if (job != null)
            {
                return View(job);
            }
            return View();
        }
        public async Task<ActionResult> AddJob()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddJob(ViewModels.AddJobs newJob)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addJob = new Models.Job
                    {
                        IdJob = newJob.IdJob,
                        Title = newJob.Title,
                        Status = newJob.Status,
                        IsDeleted = true,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Jobs.Add(addJob);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Job");

                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditJob(int id)
        {
            var job = await db.Jobs.Where(x => x.IdJob == id && x.IsDeleted == true).SingleOrDefaultAsync();
            if (job != null)
            {
                return View(job);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditJob(ViewModels.AddJobs updateJob)
        {
            if (updateJob != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editJob = new Models.Job
                    {
                        IdJob = updateJob.IdJob,
                        Title = updateJob.Title,
                        Status = updateJob.Status,
                        IsDeleted = true,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(editJob).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Job");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteJob(ViewModels.EditJobs updateJob)
        {
            if (updateJob != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var Job = new Models.Job
                    {
                        IsDeleted = true,
                        DeletedBy = currentUser,
                        Deleted = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Entry(Job).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Job");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/

        public async Task<ActionResult> Citizen()
        {
            var Citizen = await db.Citizens.Where(x => x.IsBanned == false).ToListAsync();
            if (Citizen != null)
            {
                return View(Citizen);
            }
            return View();
        }
        public async Task<ActionResult> DetailCitizen(string id)
        {
            var Citizen = await db.Citizens.Where(x => x.Id == id && x.IsBanned == false).SingleOrDefaultAsync();
            if (Citizen != null)
            {
                return View(Citizen);
            }
            return View();
        }
        public async Task<ActionResult> AddCitizen()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddCitizen(ViewModels.AddCitizen newCitizen)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addCitizen = new Models.Citizens
                    {
                        NIK = newCitizen.NIK,
                        Title = newCitizen.FullName,
                        RegistrationStatus = newCitizen.RegistrationStatus,
                        IsBanned = true,
                        Avatar = newCitizen.Avatar,
                        Address = newCitizen.Address,
                        RT = newCitizen.RT,
                        RW = newCitizen.RW,
                        Descriptions = newCitizen.Descriptions,
                        Job = newCitizen.Job,
                        Gender = newCitizen.Gender
                    };
                    try
                    {
                        db.Citizens.Add(addCitizen);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Citizen");

                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditCitizen(string id)
        {
            var Citizen = await db.Citizens.Where(x => x.Id == id && x.IsBanned == true).SingleOrDefaultAsync();
            if (Citizen != null)
            {
                return View(Citizen);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditCitizen(ViewModels.AddCitizen updateCitizen)
        {
            if (updateCitizen != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var editCitizen = new Models.Citizens
                    {
                        NIK = updateCitizen.NIK,
                        Title = updateCitizen.FullName,
                        RegistrationStatus = updateCitizen.RegistrationStatus,
                        IsBanned = true,
                        Avatar = updateCitizen.Avatar,
                        Address = updateCitizen.Address,
                        RT = updateCitizen.RT,
                        RW = updateCitizen.RW,
                        Descriptions = updateCitizen.Descriptions,
                        Job = updateCitizen.Job,
                        Gender = updateCitizen.Gender
                    };
                    try
                    {
                        db.Entry(editCitizen).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Citizen");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteCitizen(ViewModels.EditCitizen updateCitizen)
        {
            if (updateCitizen != null)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var Citizen = new Models.Citizens
                    {
                        IsBanned = true,
                    };
                    try
                    {
                        db.Entry(Citizen).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Citizen");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
            }
            return View("Error");
        }
        /*-------------------------------------------------------------------*/
        public async Task<ActionResult> DocumentSubmissionList()
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => x.Status == Models.Status.Pending).ToListAsync();
            if(documents != null)
            {
                return View(documents);
            }
            return View();
            
        }
        public async Task<ActionResult> ApproveDocumentSubmissionList()
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => x.Status == Models.Status.Pending).ToListAsync();
            var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                .SingleOrDefaultAsync();
            if (currentUser != null)
            {
                var document = new Models.Document
                {
                    ApprovedAt = DateTimeOffset.UtcNow,
                    ApprovedBy = currentUser,
                    Status = Models.Status.Approved
                  
                };
                try
                {
                    db.Entry(document).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return RedirectToAction("Citizen");
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                }
            }
            return View();

        }
        public async Task<ActionResult> DocumentSubmissionHistory()
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => (x.Status == Models.Status.Approved || x.Status == Models.Status.Rejected) &&  x.IsDeleted == false).ToListAsync();
            if (documents != null)
            {
                return View(documents);
            }
            return View();
        }
        public async Task<ActionResult> Report()
        {
            return View();
        }
    }
}