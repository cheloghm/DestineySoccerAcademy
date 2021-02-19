using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DestineySoccerAcademy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, StringLength(15)]
        public string MobilePhone { get; set; }

        [Required, StringLength(500)]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        //[Required]
        public DateTime? Birthdate { get; set; }

        public DateTime Create_date { get; set; }
        // Here we add a byte to Save the user Profile Pictuer  
        public byte[] ProfilePhoto { get; set; }
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

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DestineySoccerAcademy.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}