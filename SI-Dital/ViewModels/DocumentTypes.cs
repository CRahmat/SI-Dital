using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class DocumentType
    {
    }
    public class AddDocumentType
    {
        [Required(ErrorMessage = "Id tidak boleh kosong")]
        [Remote("IsIdDocumentTypeExists", "Hosts", HttpMethod = "POST", ErrorMessage = "Nama ID sudah digunakan")]
        [RegularExpression("[a-zA-Z0-9&-]+", ErrorMessage = "Hanya dapat menggunakan format ( A-Z, 0-9 dan - )")]
        [Display(Name = "ID-Dokumen")]
        public string IdDocumentType { get; set; }
        [Display(Name = "Nama Dokumen")]
        public string Name { get; set; }
        [Display(Name = "Nama Dokumen")]
        public string FileDocument { get; set; }
        [Display(Name = "No Urut")]
        public int Order { get; set; }

    }
    public class EditDocumentType
    {
        [Display(Name = "ID-Dokumen")]
        public string IdDocumentType { get; set; }
        [Display(Name = "Nama Dokumen")]
        public string Name { get; set; }
        [Display(Name = "No Urut")]
        public int Order { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset Updated { get; set; }
        public EditDocumentType()
        {
            //Default Constructor
        }

        public EditDocumentType(SI_Dital.Models.DocumentGroup DocumentType)
        {

            IdDocumentType = DocumentType.Permalink;
            Name = DocumentType.Title;
            Order = DocumentType.Order;
            UpdatedBy = DocumentType.UpdatedBy;
            Updated = DocumentType.Updated;
            IsDeleted = DocumentType.IsDeleted;
        }
    }
    public class DetailsDocumentType
    {
        public string IdDocumentType { get; set; }
        public string Name { get; set; }
        public string Order { get; set; }
    }
}