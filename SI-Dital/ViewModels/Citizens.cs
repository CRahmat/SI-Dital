using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.ViewModels
{
    public class Citizens
    {
    }
    public class AddCitizen
    {
        public string NIK { get; set; }
        [Required(ErrorMessage = "Nama lengkap wajib diisi")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Remote("IsValidEmail", "Account", HttpMethod = "POST", ErrorMessage = "Email sudah digunakan")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [Required(ErrorMessage = "Alamat email wajib diisi")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid")]
        [Required(ErrorMessage = "Nomor telepon wajib diisi")]
        [Display(Name = "Nomor HP")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        [RegularExpression(@"^(1[ \-\+]{0,3}|\+1[ -\+]{0,3}|\+1|\+)?((\(\+?1-[2-9][0-9]{1,2}\))|(\(\+?[2-8][0-9][0-9]\))|(\(\+?[1-9][0-9]\))|(\(\+?[17]\))|(\([2-9][2-9]\))|([ \-\.]{0,3}[0-9]{2,4}))?([ \-\.][0-9])?([ \-\.]{0,3}[0-9]{2,4}){2,3}$", ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Kata sandi wajib diisi")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Panjang karakter minimal 6.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Kata sandi harus sama.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Tanggal Lahir wajib diisi")]
        [Display(Name = "Tanggal Lahir")]
        public DateTimeOffset DOB { get; set; }
        [Required(ErrorMessage = "Provinsi wajib diisi")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Wajib memilih Kota/Kabupaten")]
        public string City { get; set; }
        [Display(Name = "Institusi")]
        public string Institution { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "Alamat Lengkap")]
        public string Address { get; set; }
        public Models.RT RT { get; set; }
        public Models.RW RW { get; set; }
        [Display(Name = "Pekerjaan")]
        public Models.Job Job { get; set; }
        [Display(Name = "Deskripsi")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Wajib diisi")]
        public RegistrationStatus RegistrationStatus { get; set; }
        [Display(Name = "Jenis Kelamin")]
        public bool Gender { get; set; }
        [Display(Name = "Status Pernikahan")]
        public bool MaritalStatus { set; get; }
        [Display(Name = "Kewarganegaraan")]
        public string Citizenship { set; get; }
        [Display(Name = "Agama")]
        public Religion Religion { set; get; }
        [Display(Name = "Jabatan Di Desa")]
        public Roles Roles { set; get; }
    }
    public class EditCitizen
    {
        public string NIK { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public Models.RT RT { get; set; }
        public Models.RW RW { get; set; }
        public Models.Job Job { get; set; }
        public string Descriptions { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { set; get; }
        public string Citizenship { set; get; }
        public Religion Religion { set; get; }
    }
}