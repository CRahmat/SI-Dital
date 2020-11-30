using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class AddJobs
    {
        [Required(ErrorMessage = "Id tidak boleh kosong")]
        [Remote("IsIdHamletExists", "Hosts", HttpMethod = "POST", ErrorMessage = "Nama id sudah digunakan")]
        [RegularExpression("[a-zA-Z0-9&-]+", ErrorMessage = "Hanya dapat menggunakan format ( A-Z, 0-9 dan - )")]
        [Display(Name = "ID-Pekerjaan")]
        public int IdJob { get; set; }
        [Display(Name = "Nama Pekerjaan")]
        public string Title { get; set; }
        public Status Status { get; set; }
    }
    public class EditJobs
    {
        [Display(Name = "ID-Pekerjaan")]
        public int IdJob { get; set; }
        [Display(Name = "Nama Pekerjaan")]
        public string Title { get; set; }
        public Status Status { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset Updated { get; set; }
        public EditJobs()
        {
            //Default Constructor
        }

        public EditJobs(SI_Dital.Models.Job job)
        {

            IdJob = job.IdJob;
            Title = job.Title;
            Status = job.Status;
            UpdatedBy = job.UpdatedBy;
            Updated = job.Updated;
            IsDeleted = job.IsDeleted;
        }
    }
    public class DetailsJob
    {
        public int IdJob { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
    }
}