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
        public Departement Departement { set; get; }
        public bool Gender { set; get; }
        public bool Status { set; get; }
        public bool MaritalStatus { set; get; }
        public string Citizenship { set; get; }
        public DateTimeOffset DOB { get; set; }
        public RT RT { set; get; }
        public RW RW { set; get; }
        public string NIK { set; get; }
        public Job Job { set; get; }
        public Religion Religion { set; get; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ApplicationUser RegisteredBy { set; get; }
        public virtual ApplicationUser UpdatedBy { set; get; }
        public DateTimeOffset Registered { get; set; }
        public DateTimeOffset Updated { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
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
    }
    public enum RegistrationStatus
    {
        Rejected,
        Approved,
        Pending
    }
    public enum Departement
    {
        VillageHead,
        Admin,
        Citizen
    }
    public enum Religion
    {
        Islam,
        Kristen,
        Katolik,
        Hindu,
        Budha,
        KongHuCu
    }
}