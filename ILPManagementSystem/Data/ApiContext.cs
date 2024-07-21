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

        public DbSet<SessionAttendance> SessionAttendances { get; set; }


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
            modelBuilder.Entity<DocumentLinks>()
                .Property(u => u.documentType)
                .HasConversion<string>();


        }

    }
}
