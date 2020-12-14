using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI_Dital.ViewModels
{
    public class FileDocuments
    {
        public string IdFileDocument { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Nama")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi X Nama")]
        public double NameXPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi Y Nama")]
        public double NameYPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi X QR")]
        public double QRXPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi Y QR")]
        public double QRYPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Ukuran Font")]
        public double FontSize { get; set; }
        public string Url { get; set; }
        public Status Status { get; set; }

        public FileDocuments()
        {

        }
    }

    public class EditFileDocuments
    {
        public string IdFileDocument { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Nama")]
        public string Name { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi X Nama")]
        public double NameXPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi Y Nama")]
        public double NameYPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi X QR")]
        public double QRXPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Posisi Y QR")]
        public double QRYPosition { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        [Display(Name = "Ukuran Font")]
        public double FontSize { get; set; }
        public Status Status { get; set; }
    }

    public class EventFileDocuments
    {
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string PhoneNumber { get; set; }
        public string Permalink { get; set; }
        public string IdFileDocument { get; set; }
    }
    public class UpdateFileDocumentInfo
    {
        public string FullName { get; set; }
        public string Province { get; set; }
        public string Title { get; set; }
        public string Institution { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        [Display(Name = "Berlangganan Informasi Acara")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Anda belum memilih berlangganan")]
        public string Subscribe { get; set; }
        public string IdTransaction { get; set; }
    }
}