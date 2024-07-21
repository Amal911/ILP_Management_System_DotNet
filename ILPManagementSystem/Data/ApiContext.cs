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
        public DbSet<Scorecard> Scorecards { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BatchType> BatchTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<BatchPhase> BatchPhase {  get; set; }

        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<PhaseAssessmentTypeMapping> PhaseAssessmentTypeMappings { get; set; }


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
                    PhaseName = "E-Learning"
                },
                new Phase
                {
                    Id = 2,
                    PhaseName = "Tech Fundamentals"
                },
                new Phase
                {
                    Id = 3,
                    PhaseName = "Business Orientation"
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

            modelBuilder.Entity<BatchPhase>().HasOne(u => u.Batch).WithMany(b => b.BatchPhases).HasForeignKey(u => u.BatchId);
            modelBuilder.Entity<BatchPhase>().HasOne(u => u.Phase).WithMany(b => b.BatchPhases).HasForeignKey(u => u.PhaseId);
            modelBuilder.Entity<BatchPhase>().HasMany(u => u.PhaseAssessmentTypeMappings).WithOne(b => b.BatchPhase);

            modelBuilder.Entity<PhaseAssessmentTypeMapping>().HasOne(u => u.AssessmentType).WithMany(b => b.PhaseAssessmentTypeMappings).HasForeignKey(u => u.AssessmentTypeId);
            modelBuilder.Entity<PhaseAssessmentTypeMapping>().HasOne(u=>u.BatchPhase).WithMany(b=>b.PhaseAssessmentTypeMappings).HasForeignKey(u=>u.BatchPhaseId);
        }

    }
}
