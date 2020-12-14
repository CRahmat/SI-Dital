using Microsoft.AspNet.Identity.EntityFramework;
using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SI_Dital.Infrastructures
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<RT> RT { get; set; }
        public DbSet<RW> RW { get; set; }
        public DbSet<Hamlet> Hamlets { get; set; }
        public DbSet<Citizens> Citizens { get; set; }
        public DbSet<DocumentGroup> DocumentTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FileDocuments> FileDocuments { get; set; }
    }
}