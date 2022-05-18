using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Archive.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("DB_USERNAME",UserName));
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DARCMS");
            base.OnModelCreating(modelBuilder);
            //

            modelBuilder.Entity<IdentityUser>()
                    .ToTable("u_users_tb", "DARCMS").Property(p => p.Id).HasColumnName("ID");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("u_users_tb", "DARCMS").Property(p => p.Id).HasColumnName("ID");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("u_users_tb", "DARCMS").Property(p => p.UserId).HasColumnName("ID");
            //modelBuilder.Entity<IdentityUser>()
            //      .ToTable("u_users_tb", "DARCMS").Property(p => p.UserName).HasColumnName("EMP_NAME");
            //modelBuilder.Entity<User>()
            //    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");
            //modelBuilder.HasDefaultSchema("darcms".ToUpper());
            //base.OnModelCreating(modelBuilder);



            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUser>()
            //    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");
            //modelBuilder.Entity<User>()
            //    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");

            //modelBuilder.Entity<ApplicationUser>().ToTable("u_users_tb","darcms".ToUpper());
            //modelBuilder.Entity<IdentityUser>().ToTable("u_users_tb", "darcms".ToUpper());
            //modelBuilder.Entity<IdentityRole>().ToTable("Role");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}