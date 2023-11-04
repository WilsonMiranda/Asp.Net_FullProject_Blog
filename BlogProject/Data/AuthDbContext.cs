using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
    //authentication db context
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        // Add DbSet for  models 
        override protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed roles (User,Admin, SuperAdmin)

            var superAdminRoleId = "c37471c9-08f5-4c02-b1b2-625ab9de713f";
            var adminRoleId = "f6817ce4-0424-4adf-adb4-c7d3b8cd3e65";
            var userRoleId = "0b4f6009-7c3f-4791-8306-571190d42ee1";

            var roles = new List<IdentityRole>
            {
                 new IdentityRole
               {
                   Name = "SuperAdmin",
                   NormalizedName = "SuperAdmin",
                   Id = superAdminRoleId,
                   ConcurrencyStamp = superAdminRoleId
               },
               new IdentityRole
               {
                   Name = "Admin",
                   NormalizedName = "Admin",
                   Id = adminRoleId,
                   ConcurrencyStamp = adminRoleId
               },
               new IdentityRole
               {
                     Name = "User",
                     NormalizedName = "User",
                     Id = userRoleId,
                     ConcurrencyStamp = userRoleId
                }
              

            };

            builder.Entity<IdentityRole>().HasData(roles);

            //seed SuperAdminUser
            var superAdminId = "47f99196-20ed-4496-ba4a-8d68fbea6fe7";
            var superAdminUser = new IdentityUser
            {

                UserName = "superadmin",
                NormalizedUserName = "superadmin".ToUpper(),
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                Id = superAdminId

            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //add all roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
