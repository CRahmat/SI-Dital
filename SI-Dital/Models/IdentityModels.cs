using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SI_Dital.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTimeOffset Registered { get; set; }
        public DateTimeOffset Updated { get; set; }
        public bool IsBanned { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public string Descriptions { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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