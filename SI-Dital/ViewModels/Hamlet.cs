using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class Hamlet
    {
    }
    public class AddHamlet
    {
        [Required(ErrorMessage = "Id tidak boleh kosong")]
        [Remote("IsIdHamletExists", "Hosts", HttpMethod = "POST", ErrorMessage = "Nama id sudah digunakan")]
        [RegularExpression("[a-zA-Z0-9&-]+", ErrorMessage = "Hanya dapat menggunakan format ( A-Z, 0-9 dan - )")]
        [Display(Name = "ID-Pedukuhan")]
        public string IdHamlet { get; set; }
        [Display(Name = "Nama Pedukuhan")]
        public string Name { get; set; }
        [Display(Name = "Ketua Dukuh")]
        public string Chairman { get; set; }

    }
    public class EditHamlet
    {
        [Display(Name = "ID-Pedukuhan")]
        public string IdHamlet { get; set; }
        [Display(Name = "Nama Pedukuhan")]
        public string Name { get; set; }
        [Display(Name = "Ketua Dukuh")]
        public string Chairman { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset Updated { get; set; }
        public EditHamlet()
        {
            //Default Constructor
        }

        public EditHamlet(SI_Dital.Models.Hamlet Hamlet)
        {

            IdHamlet = Hamlet.IdHamlet;
            Name = Hamlet.Name;
            Chairman = Hamlet.Chairman;
            UpdatedBy = Hamlet.UpdatedBy;
            Updated = Hamlet.Updated;
            IsActive = Hamlet.IsActive;
        }
    }
    public class DetailsHamlet
    {
        public string IdHamlet { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
    }
}