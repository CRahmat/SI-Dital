using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SI_Dital.Models
{
    [Table("Citizens")]
    public class Citizens : ApplicationUser
    {
        public string NIK { set; get; }
        public Job Job {set; get;}
        public bool Gender { set; get; }
        public bool Status { set; get; }
        public DateTimeOffset DOB { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

    }
    [Table("Admin")]
    public class Admin : ApplicationUser
    {
        public string NIK { set; get; }
        public Job Job { set; get; }
        public bool Gender { set; get; }
        public bool Status { set; get; }
        public virtual ICollection<Document> Documents { get; set; }

    }
    [Table("VillageHead")]
    public class VillageHead : ApplicationUser
    {
        public string NIK { set; get; }
        public Job Job { set; get; }
        public bool Gender { set; get; }
        public bool Status { set; get; }
        public DateTimeOffset Starred { get; set; }
        public DateTimeOffset Ended { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
    public class Metadata
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset Deleted { get; set; }
        public DateTimeOffset Published { get; set; }
        public DateTimeOffset Approved { get; set; }
        public Status Status { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public virtual ApplicationUser DeletedBy { get; set; }
        public virtual ApplicationUser PublishedBy { get; set; }
        public virtual ApplicationUser ApprovedBy { get; set; }

        public Metadata()
        {
            this.Created = DateTimeOffset.UtcNow;
            this.Updated = DateTimeOffset.UtcNow;
        }
        public Metadata(ApplicationUser user)
        {
            this.CreatedBy = user;
            this.UpdatedBy = user;
            this.Created = DateTimeOffset.UtcNow;
            this.Updated = DateTimeOffset.UtcNow;
        }
    }

    [Table("Job")]
    public class Job : Metadata
    {
        [Key]
        public int IdJob { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
    }
    public enum RegistrationStatus
    {
        Rejected,
        Approved,
        Pending
    }
}