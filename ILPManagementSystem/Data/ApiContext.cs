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

        public DbSet<Phase> Phases { get; set; }

        public DbSet<BatchPhase> BatchPhase {  get; set; }
        public DbSet<CompletedAssessmentDTO> CompletedAssessment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

/*
            modelBuilder.Entity<Batch>()
                .HasOne(r => r.batchType)
                .WithMany(b=>b.batchList)
                .HasForeignKey(r => r.batchId);*/

        }

    }
}
