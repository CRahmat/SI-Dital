using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class RT
    {
    }
    public class AddRT
    {
        [Required(ErrorMessage = "Id tidak boleh kosong")]
        [Remote("IsIdRTExists", "Hosts", HttpMethod = "POST", ErrorMessage = "Nama id sudah digunakan")]
        [RegularExpression("[a-zA-Z0-9&-]+", ErrorMessage = "Hanya dapat menggunakan format ( A-Z, 0-9 dan - )")]
        [Display(Name = "ID-RT")]
        public string IdRT { get; set; }
        [Display(Name = "Nama RT")]
        public string Name { get; set; }
        [Display(Name = "Ketua RT")]
        public string Chairman { get; set; }

    }
    public class EditRT
    {
        [Display(Name = "ID-RT")]
        public string IdRT { get; set; }
        [Display(Name = "Nama RT")]
        public string Name { get; set; }
        [Display(Name = "Ketua RT")]
        public string Chairman { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset Updated { get; set; }
        public EditRT()
        {
            //Default Constructor
        }

        public EditRT(SI_Dital.Models.RT RT)
        {

            IdRT = RT.IdRT;
            Name = RT.Name;
            Chairman = RT.Chairman;
            UpdatedBy = RT.UpdatedBy;
            Updated = RT.Updated;
            IsActive = RT.IsActive;
        }
    }
    public class DetailsRT
    {
        public string IdRT { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
    }
}