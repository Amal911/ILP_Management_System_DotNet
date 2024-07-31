using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml;

namespace ILPManagementSystem.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
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
        public DbSet<CompletedAssessment> CompletedAssessment { get; set; }

        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<DocumentLinks> DocumentLinks { get; set; }
        public DbSet<PhaseAssessmentTypeMapping> PhaseAssessmentTypeMappings { get; set; }

        public DbSet<SessionAttendance> SessionAttendances { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BatchProgram> Programs { get; set; }

        public DbSet<Attendance> Attendances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var LocationList = new List<Location>() {
                new Location
                {
                    Id = 1,
                    LocationName="Trivandrum"
                },
                new Location
                {
                    Id = 2,
                    LocationName="Kochi"
                }
                };
            modelBuilder.Entity<Location>().HasData(LocationList);

            var BatchTypeList = new List<BatchType>()
            {
                new BatchType
                {
                    Id=1,
                    BatchTypeName = "Technical"
                },
                new BatchType
                {
                    Id=2,
                    BatchTypeName = "BA"
                },
            };
            modelBuilder.Entity<BatchType>().HasData(BatchTypeList);

            var PhaseList = new List<Phase>()
            {
                new Phase
                {
                    Id = 1,
                    PhaseName = "E-Learning",
                    PhaseDuration= 20
                },
                new Phase
                {
                    Id = 2,
                    PhaseName = "Tech Fundamentals",
                    PhaseDuration= 40
                },
                new Phase
                {
                    Id = 3,
                    PhaseName = "Business Orientation",
                    PhaseDuration= 30
                },
            };
            modelBuilder.Entity<Phase>().HasData(PhaseList);

            var AssessmentTypeList = new List<AssessmentType>()
            {
                new AssessmentType
                {
                    Id = 1,
                    AssessmentTypeName = "Daily Assessment"
                },
                new AssessmentType
                {
                    Id = 2,
                    AssessmentTypeName = "Live Assessment"
                },
                new AssessmentType
                {
                    Id = 3,
                    AssessmentTypeName = "Case Study"
                },
            };
            modelBuilder.Entity<AssessmentType>().HasData(AssessmentTypeList);

            modelBuilder.Entity<Batch>().HasOne(u => u.BatchType).WithMany(b => b.Batches).HasForeignKey(u => u.BatchTypeId);
            modelBuilder.Entity<Batch>()
                .HasOne(r => r.Location)
                .WithMany(b => b.Batches)
                .HasForeignKey(r => r.LocationId);
            modelBuilder.Entity<Role>().HasData(
             new Role { Id = 1, RoleName = "Admin" },
             new Role { Id = 2, RoleName = "Trainer" },
             new Role { Id = 3, RoleName = "Trainee" }
          );


            modelBuilder.Entity<User>()
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>().Property(u => u.Gender).HasConversion<int>();
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


            modelBuilder.Entity<BatchPhase>().HasOne(u => u.Batch).WithMany(b => b.BatchPhases).HasForeignKey(u => u.BatchId);
            modelBuilder.Entity<BatchPhase>().HasOne(u => u.Phase).WithMany(b => b.BatchPhases).HasForeignKey(u => u.PhaseId);
            modelBuilder.Entity<BatchPhase>().HasMany(u => u.PhaseAssessmentTypeMappings).WithOne(b => b.BatchPhase);

            modelBuilder.Entity<Leave>()
            .HasMany(l => l.LeaveApprovals)
            .WithOne(la => la.Leaves)
            .HasForeignKey(la => la.LeavesId);

            modelBuilder.Entity<LeaveApproval>()
                .HasOne(la => la.User)
                .WithMany()
                .HasForeignKey(la => la.userId);

            modelBuilder.Entity<PhaseAssessmentTypeMapping>().HasOne(u => u.AssessmentType).WithMany(b => b.PhaseAssessmentTypeMappings).HasForeignKey(u => u.AssessmentTypeId);

            modelBuilder.Entity<PhaseAssessmentTypeMapping>().HasOne(u=>u.BatchPhase).WithMany(b=>b.PhaseAssessmentTypeMappings).HasForeignKey(u=>u.BatchPhaseId);
  

            modelBuilder.Entity<PhaseAssessmentTypeMapping>().HasOne(u => u.BatchPhase).WithMany(b => b.PhaseAssessmentTypeMappings).HasForeignKey(u => u.BatchPhaseId);

            modelBuilder.Entity<Trainee>().HasOne(u => u.User).WithOne(b => b.Trainee);
            modelBuilder.Entity<Trainee>().HasOne(u => u.Batch).WithMany(b => b.TraineeList).HasForeignKey(u => u.BatchId);

            modelBuilder.Entity<Trainer>().HasOne(u => u.User).WithOne(b => b.Trainer);
            modelBuilder.Entity<Admin>().HasOne(u => u.User);

            modelBuilder.Entity<Assessment>().HasOne(u => u.Trainer);
            modelBuilder.Entity<Assessment>().HasOne(u => u.AssessmentType);
            modelBuilder.Entity<Batch>().HasOne(u => u.Program).WithMany(b => b.BatchList);


            modelBuilder.Entity<BatchProgram>().HasData(
                new BatchProgram { Id = 1, ProgramName = "2023-2024" },
                new BatchProgram { Id = 2, ProgramName = "2024-2025" }
                );
            modelBuilder.Entity<Trainer>().HasData(
                new Trainer
                {
                    Id = 1,
                    userId = 3,
                },
                new Trainer
                {
                    Id = 2,
                    userId = 4,
                }
                );

        }           

    }
}
