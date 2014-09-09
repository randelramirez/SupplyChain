//using System.Data.Entity;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace ExtendingAspNetIdentity.Models
//{
//    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
//    //public class ApplicationUser : IdentityUser
//    //{
//    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
//    //    {
//    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//    //        // Add custom user claims here
//    //        return userIdentity;
//    //    }
//    //}

//    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    //{
//    //    public ApplicationDbContext()
//    //        : base("DefaultConnection", throwIfV1Schema: false)
//    //    {
//    //    }

//    //    public static ApplicationDbContext Create()
//    //    {
//    //        return new ApplicationDbContext();
//    //    }
//    //}

//    // http://stackoverflow.com/questions/22855428/how-to-change-table-names-for-asp-net-identity-2-0-with-int-id-columns
//    public class CustomUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
//    {
//    }

//    public class UserLogin : IdentityUserLogin<int>
//    {
//    }

//    public class Role : IdentityRole<int, UserRole>
//    {
//        public string Description { get; set; }  // Custom description field on roles
//    }

//    public class UserRole : IdentityUserRole<int>
//    {
//    }

//    public class UserClaim : IdentityUserClaim<int>
//    {
//    }

//    public class MyDbContext : IdentityDbContext<CustomUser, Role, int, UserLogin, UserRole, UserClaim>
//    {
//        public MyDbContext() : this("MyDB") { }

//        public MyDbContext(string connStringName)
//            : base(connStringName)
//        {
//            this.Configuration.LazyLoadingEnabled = false;
//            this.Configuration.ProxyCreationEnabled = false;
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {

//            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

//            modelBuilder.Entity<User>().ToTable("Users");
//            modelBuilder.Entity<Role>().ToTable("Roles");
//            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
//            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
//            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");

          
//        }
//    }
//}