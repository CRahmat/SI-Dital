using SI_Dital.Helpers;
using SI_Dital.Controllers;
using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace SI_Dital.Controllers
{
    public class VillageHeadController : BaseController
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
                            return RedirectToAction("RT","VillageHead");
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
                            return RedirectToAction("RT","VillageHead");
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
                            return RedirectToAction("RT","VillageHead");
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
                            return RedirectToAction("RW","VillageHead");
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
                            return RedirectToAction("RW","VillageHead");
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
                            return RedirectToAction("RW","VillageHead");
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
            var fileDocuments = await db.FileDocuments.Where(x => x.IsDeleted == false)
            .Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.IdFileDocument.ToString(),
                Selected = false
            }).ToArrayAsync();
            ViewBag.FileDocuments = fileDocuments;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDocumentType(ViewModels.AddDocumentType newDocumentType)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                var fileDocument = await db.FileDocuments.Where(x => x.IdFileDocument == newDocumentType.FileDocument).SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var addDocumentType = new Models.DocumentGroup
                    {
                        Permalink = newDocumentType.IdDocumentType,
                        Title = newDocumentType.Name,
                        FileDocuments = fileDocument,
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
                         return RedirectToAction("DocumentType","VillageHead");
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
                         return RedirectToAction("DocumentType","VillageHead");
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
                            return RedirectToAction("DocumentType","VillageHead");
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
                            return RedirectToAction("Hamlet","VillageHead");

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
                            return RedirectToAction("Hamlet","VillageHead");
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
                            return RedirectToAction("Hamlet","VillageHead");
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
                        IsDeleted = false,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow
                    };
                    try
                    {
                        db.Jobs.Add(addJob);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Job","VillageHead");

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
                            return RedirectToAction("Job","VillageHead");
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
                            return RedirectToAction("Job","VillageHead");
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
            var Citizen = await db.Citizens.Include("RT").Include("RW").Where(x => x.IsBanned == false).ToListAsync();
            if (Citizen != null)
            {
                return View(Citizen);
            }
            return View();
        }
        public async Task<ActionResult> DetailCitizen(string id)
        {
            var Citizen = await db.Citizens.Include("RT").Include("RW").Where(x => x.Id == id && x.IsBanned == false).SingleOrDefaultAsync();
            if (Citizen != null)
            {
                return View(Citizen);
            }
            return View();
        }
        public async Task<ActionResult> AddCitizen()
        {
            var job = await db.Jobs.Where(x => x.IsDeleted == false)
                .Select(i => new SelectListItem()
                {
                    Text = i.Title,
                    Value = i.IdJob.ToString(),
                    Selected = false
                }).ToArrayAsync();
            ViewBag.Jobs = job;
            var rt = await db.RT.Where(x => x.IsDeleted == false)
                .Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.IdRT.ToString(),
                    Selected = false
                }).ToArrayAsync();
            ViewBag.RT = rt;
            var rw = await db.RW.Where(x => x.IsDeleted == false)
                .Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.IdRW.ToString(),
                    Selected = false
                }).ToArrayAsync();
            ViewBag.RW = rw;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddCitizen(ViewModels.AddCitizen newCitizen)
        {
            var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                .SingleOrDefaultAsync();
            if (currentUser != null)
            {
                try
                {
                    var searchUser = await db.Users.Where(x => x.Email == newCitizen.Email).SingleOrDefaultAsync();
                    if (searchUser == null)
                    {
                        var citizen = new Citizens
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = newCitizen.NIK,
                            Email = newCitizen.Email,
                            FullName = newCitizen.FullName,
                            PhoneNumber = newCitizen.PhoneNumber
                        };
                        var resultUserManager = await UserManager.CreateAsync(citizen, newCitizen.Password);
                        var currentCitizen = await UserManager.FindByEmailAsync(newCitizen.Email);
                        var addToRoleResult = await UserManager.AddToRoleAsync(currentCitizen.Id, "Citizen");
                        if (newCitizen.Roles == Departement.Admin)
                        {
                            addToRoleResult = await UserManager.AddToRoleAsync(currentCitizen.Id, "Administrator");
                        }
                        else if (newCitizen.Roles == Departement.VillageHead)
                        {
                            addToRoleResult = await UserManager.AddToRoleAsync(currentCitizen.Id, "VillageHead");
                        }
                        if (resultUserManager.Succeeded && addToRoleResult.Succeeded)
                        {
                            var RT = await db.RT.FindAsync(newCitizen.RT);
                            var RW = await db.RW.FindAsync(newCitizen.RW);
                            var job = await db.Jobs.FindAsync(newCitizen.Job);
                            var addCitizen = await db.Citizens.FindAsync(currentCitizen.Id);
                            if (addCitizen != null)
                            {
                                addCitizen.NIK = newCitizen.NIK;
                                addCitizen.Job = job;
                                addCitizen.DOB = newCitizen.DOB;
                                addCitizen.Religion = newCitizen.Religion;
                                addCitizen.RegisteredBy = currentUser;
                                addCitizen.Departement = newCitizen.Roles;
                                addCitizen.RegistrationStatus = newCitizen.RegistrationStatus;
                                addCitizen.RT = RT;
                                addCitizen.RW = RW;
                                addCitizen.MaritalStatus = newCitizen.MaritalStatus;
                                addCitizen.Citizenship = newCitizen.Citizenship;
                                addCitizen.Gender = newCitizen.Gender;
                                addCitizen.Institution = newCitizen.Institution;
                                addCitizen.IsBanned = false;
                                addCitizen.Address = newCitizen.Address;
                                addCitizen.EmailConfirmed = false;
                                addCitizen.Descriptions = newCitizen.Descriptions;
                            }
                            db.Entry(addCitizen).State = EntityState.Modified;
                            var result = await db.SaveChangesAsync();
                            if (result > 0)
                            {
                                return RedirectToAction("Citizen","VillageHead");

                            }
                        }
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                }
            }
            return View("Error");
        }
        public async Task<ActionResult> EditCitizen(string id)
        {
            var Citizen = await db.Citizens.Include("RT").Include("RW").Where(x => x.Id == id && x.IsBanned == true).SingleOrDefaultAsync();
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
                    var RT = await db.RT.FindAsync(updateCitizen.RT);
                    var RW = await db.RW.FindAsync(updateCitizen.RW);
                    var job = await db.Jobs.FindAsync(updateCitizen.Job);
                    var editCitizen = new Models.Citizens
                    {
                        NIK = updateCitizen.NIK,
                        FullName = updateCitizen.FullName,
                        RegistrationStatus = updateCitizen.RegistrationStatus,
                        IsBanned = true,
                        Avatar = updateCitizen.Avatar,
                        Address = updateCitizen.Address,
                        RT = RT,
                        RW = RW,
                        DOB = updateCitizen.DOB,
                        Institution = updateCitizen.Institution,
                        PhoneNumber = updateCitizen.PhoneNumber,
                        MaritalStatus = updateCitizen.MaritalStatus,
                        Religion = updateCitizen.Religion,
                        Citizenship = updateCitizen.Citizenship,
                        Descriptions = updateCitizen.Descriptions,
                        Job = job,
                        Gender = updateCitizen.Gender,
                        Departement = updateCitizen.Roles,
                        UpdatedBy = currentUser,
                        Updated = DateTime.UtcNow
                    };
                    try
                    {
                        db.Entry(editCitizen).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return RedirectToAction("Citizen","VillageHead");
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
                            return RedirectToAction("Citizen","VillageHead");
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
            if (documents != null)
            {
                return View(documents);
            }
            return View();

        }
        public async Task<ActionResult> DetailSubmission(string id)
        {
            var documents = await db.Documents.Where(x => x.IdDocument == id).SingleOrDefaultAsync();
            if (documents != null)
            {
                return View(documents);
            }
            return View();

        }
        [HttpPost]
        public async Task<ActionResult> ApproveDocumentSubmission(string IdDocument)
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => x.IdDocument == IdDocument && x.Status == Models.Status.Pending).SingleOrDefaultAsync();
            var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                .SingleOrDefaultAsync();
            if (currentUser != null && documents != null)
            {
                documents.Approved = DateTime.UtcNow;
                documents.ApprovedBy = currentUser;
                documents.Status = Status.Approved;
                try
                {
                    db.Entry(documents).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return RedirectToAction("DocumentSubmissionList");
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                }
            }
            return View("Error");

        }
        public async Task<ActionResult> DocumentSubmissionHistory()
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => (x.Status == Models.Status.Approved || x.Status == Models.Status.Rejected) && x.IsDeleted == false).ToListAsync();
            if (documents != null)
            {
                return View(documents);
            }
            return View();
        }
        public async Task<ActionResult> DetailSubmissionHistory(string id)
        {
            var documents = await db.Documents.Where(x => x.IdDocument == id).SingleOrDefaultAsync();
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
        [HttpGet]
        public ActionResult AddFileDocument()
        {
            return View();
        }
        public async Task<ActionResult> FileDocument()
        {
            var fileDocument = await db.FileDocuments.Where(x => x.IsDeleted == false).ToListAsync();
            return View(fileDocument);
        }
        [HttpPost]
        public async Task<ActionResult> AddFileDocument(ViewModels.FileDocuments model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                        .SingleOrDefaultAsync();
                    var currentTime = DateTimeOffset.UtcNow;
                    byte[] uploadedFile = new byte[model.File.InputStream.Length];
                    model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                    var document = new FileDocuments()
                    {
                        IdFileDocument = Guid.NewGuid().ToString(),
                        Name = model.Name,
                        File = uploadedFile,
                        NameXPosition = model.NameXPosition,
                        NameYPosition = model.NameYPosition,
                        QRXPosition = model.QRXPosition,
                        QRYPosition = model.QRYPosition,
                        FontSize = model.FontSize,
                        Status = model.Status,
                        Created = currentTime,
                        Updated = currentTime,
                        CreatedBy = currentUser,
                        UpdatedBy = currentUser
                    };

                    db.FileDocuments.Add(document);
                    var result = await db.SaveChangesAsync();
                    if (result > 0)
                        return RedirectToAction("FileDocuments");
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                    throw new HttpException(500, "Error on Processing Administrators Add FileDocument");
                }
            }
            return View();
        }
    }
}