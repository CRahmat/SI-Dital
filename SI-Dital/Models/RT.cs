using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SI_Dital.Models
{
    [Table("RT")]
    public class RT : Metadata
    {
        [Key]
        public string IdRT { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
        public bool IsActive { get; set; }
    }
}