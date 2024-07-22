using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ILPManagementSystem.Data
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> dbContextOptions): base (dbContextOptions)
        {
            
        }
        public DbSet<User>  Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Scorecard> Scorecards { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BatchType> BatchTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveApproval> LeaveApprovals { get; set; }

        public DbSet<Phase> Phases { get; set; }
        public DbSet<BatchPhase> BatchPhase {  get; set; }
        public DbSet<CompletedAssessmentDTO> CompletedAssessment { get; set; }

        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<DocumentLinks> DocumentLinks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Role>().HasData(
             new Role { Id = 1, RoleName = "Admin" },
             new Role { Id = 2, RoleName = "Trainer" },
             new Role { Id = 3, RoleName = "Trainee" }
          );

            modelBuilder.Entity<User>()
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId);
            /*
                        modelBuilder.Entity<Batch>()
                            .HasOne(r => r.batchType)
                            .WithMany(b=>b.batchList)
                            .HasForeignKey(r => r.batchId);*/

            //Storing Document type enum as string in the DB

            modelBuilder.Entity<User>().HasData(
       new User
       {
           Id = 1,
           EmailId = "amal_admin@sreegcloudgmail.onmicrosoft.com",
           Password = "Gowo690819",
           RoleId = 1,
           MobileNumber = "1234567890",
           FirstName = "Amal",
           LastName = "Admin",
           Gender = Gender.Male,
           IsActive = true
       },
       new User
       {
           Id = 2,
           EmailId = "devipriya_admin@sreegcloudgmail.onmicrosoft.com",
           Password = "Vajo021247",
           RoleId = 1,
           MobileNumber = "1234567891",
           FirstName = "Devipriya",
           LastName = "Admin",
           Gender = Gender.Female,
           IsActive = true
       },
       new User
       {
           Id = 3,
           EmailId = "suneesh.thampi@sreegcloudgmail.onmicrosoft.com",
           Password = "Huna544047",
           RoleId = 2,
           MobileNumber = "1234567892",
           FirstName = "Suneesh",
           LastName = "Thampi",
           Gender = Gender.Male,
           IsActive = true
       },
       new User
       {
           Id = 4,
           EmailId = "lekshmi.a@sreegcloudgmail.onmicrosoft.com",
           Password = "Quwu856933",
           RoleId = 2,
           MobileNumber = "1234567893",
           FirstName = "Lekshmi",
           LastName = "A",
           Gender = Gender.Female,
           IsActive = true
       },
       new User
       {
           Id = 5,
           EmailId = "jisna.george@sreegcloudgmail.onmicrosoft.com",
           Password = "Koso191442",
           RoleId = 3,
           MobileNumber = "1234567894",
           FirstName = "Jisna",
           LastName = "George",
           Gender = Gender.Female,
           IsActive = true
       },
       new User
       {
           Id = 6,
           EmailId = "thulasi.k@sreegcloudgmail.onmicrosoft.com",
           Password = "Toqo391712",
           RoleId = 3,
           MobileNumber = "1234567895",
           FirstName = "Thulasi",
           LastName = "K",
           Gender = Gender.Female,
           IsActive = true
       },
       new User
       {
           Id = 7,
           EmailId = "dharsan.sajeev@sreegcloudgmail.onmicrosoft.com",
           Password = "Zuja977409",
           RoleId = 3,
           MobileNumber = "1234567896",
           FirstName = "Dharsan",
           LastName = "Sajeev",
           Gender = Gender.Male,
           IsActive = true
       }
   );
            modelBuilder.Entity<DocumentLinks>()
                .Property(u => u.documentType)
                .HasConversion<string>();


        }

    }
}
