using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class RW
    {
    }
    public class AddRW
    {
        [Required(ErrorMessage = "Id tidak boleh kosong")]
        [Remote("IsIdRWExists", "Hosts", HttpMethod = "POST", ErrorMessage = "Nama id sudah digunakan")]
        [RegularExpression("[a-zA-Z0-9&-]+", ErrorMessage = "Hanya dapat menggunakan format ( A-Z, 0-9 dan - )")]
        [Display(Name = "ID-RW")]
        public string IdRW { get; set; }
        [Display(Name = "Nama RW")]
        public string Name { get; set; }
        [Display(Name = "Ketua RW")]
        public string Chairman { get; set; }

    }
    public class EditRW
    {
        [Display(Name = "ID-RW")]
        public string IdRW { get; set; }
        [Display(Name = "Nama RW")]
        public string Name { get; set; }
        [Display(Name = "Ketua RW")]
        public string Chairman { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset Updated { get; set; }
        public EditRW()
        {
            //Default Constructor
        }

        public EditRW(SI_Dital.Models.RW RW)
        {

            IdRW = RW.IdRW;
            Name = RW.Name;
            Chairman = RW.Chairman;
            UpdatedBy = RW.UpdatedBy;
            Updated = RW.Updated;
            IsActive = RW.IsActive;
        }
    }
    public class DetailsRW
    {
        public string IdRW { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
    }
}