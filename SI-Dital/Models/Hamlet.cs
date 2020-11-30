using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SI_Dital.Models
{
    [Table("Hamlet")]
    public class Hamlet : Metadata
    {
        [Key]
        public string IdHamlet { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }

        public bool IsActive { get; set; }
    }
}