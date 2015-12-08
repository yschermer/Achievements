using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Achievements.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public enum GenderEnum
    {
        Man,
        Vrouw
    }

    public enum ClassEnum
    {
        M1A,
        M1B,
        M2A,
        M2B,
        M3A,
        M3B,
        M4A,
        M4B,
        H1A,
        H1B,
        H2A,
        H2B,
        H3A,
        H3B,
        H4A,
        H4B,
        H5A,
        H5B
    }

    public class ApplicationUser : IdentityUser
    {
       
        [Required]
        public virtual string Name { get; set; }

        public virtual string Prefix { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        public virtual GenderEnum Gender { get; set; }
        public virtual DateTime BirthDate { get; set; }//DateTime werkt niet.
        public virtual string BirthCity { get; set; }
        public virtual string City { get; set; }
        //kolom Emailadres staat al in de database
        public virtual string Job { get; set; }//Alleen Teachers en Admins!
        public virtual DateTime StudyStartYear { get; set; }//Alleen Students!
        public virtual string Study { get; set; }//Alleen Students!
        public virtual ClassEnum Class { get; set; } //Alleen Teachers en Admins
   
        

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

        //public System.Data.Entity.DbSet<Achievements.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}