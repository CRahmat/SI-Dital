using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI_Dital.Models
{
    public class Document : Metadata
    {
        [Key]
        public string IdDocument { set; get; }
        public string Descriptions { get; set; }
        public DocumentGroup DocumentGroup { get; set; }
        public DateTimeOffset ApprovedAt { get; set; }

    }
    public class DocumentGroup : Metadata
    {
        [Key]
        public string Permalink { get; set; }
        public string Title { get; set; }
        public FileDocuments FileDocuments { get; set; }
        public int Order { get; set; }
    }
    public enum Status {
        Approved,
        Pending,
        OnCheck,
        Rejected
    }

}