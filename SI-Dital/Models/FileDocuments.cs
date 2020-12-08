using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI_Dital.Models
{
    public class FileDocuments : Metadata
    {
        [Key]
        public string IdFileDocument { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public double LogoXPosition { get; set; }
        public double LogoYPosition { get; set; }
        public double NameXPosition { get; set; }
        public double NameYPosition { get; set; }
        public double NameFontSize { get; set; }
        public double QRXPosition { get; set; }
        public double QRYPosition { get; set; }
        public double DocumentNameXPosition { get; set; }
        public double DocumentNameYPosition { get; set; }
        public double DocumentNameFontSize { get; set; }
        public double DocumentDateXPosition { get; set; }
        public double DocumentDateYPosition { get; set; }
        public double DocumentDateFontSize { get; set; }
        public double DocumentLocationXPosition { get; set; }
        public double DocumentLocationYPosition { get; set; }
        public double DocumentLocationFontSize { get; set; }
        public double CitizenRoleXPosition { get; set; }
        public double CitizenRoleYPosition { get; set; }
        public double CitizenRoleFontSize { get; set; }
        public double FontSize { get; set; }
    }
}