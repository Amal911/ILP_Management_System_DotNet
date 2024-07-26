using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class BatchProgramRepository : IBatchProgramRepository
    {
        private readonly ApiContext _context;

        public BatchProgramRepository(ApiContext _context)
        {
            this._context = _context;
        }
        public async Task CreateBatchProgramAsync(BatchProgram batchProgram)
        {
            await this._context.Programs.AddAsync(batchProgram);
            this._context.SaveChanges();
            
        }

        public async Task DeleteBatchProgramAsync(int Id)
        {
            BatchProgram Program = await this._context.Programs.FindAsync(Id);
            this._context.Programs.Remove(Program);

        }

        public async Task<IEnumerable<BatchProgram>> GetBatchProgramsAsync()
        {
            return (await this._context.Programs.ToListAsync());
        }
        public async Task<IEnumerable<object>> GetBatchProgramsWithBatchsAsync()
        {
            var batchList = await this._context.Programs
                .Include(u => u.BatchList)
                .Select(b =>
                    new
                    {
                        Id = b.Id,
                        ProgramName = b.ProgramName,
                        BatchList = b.BatchList.Select(x =>
                        new
                        {
                            BatchId = x.Id,
                            BatchName = x.BatchName,
                        }
                        ).ToList()
                    }).ToListAsync();
            return batchList;
        }

        public async Task<object> GetBatchProgramsAsync(int Id)
        {
            var batchList = await this._context.Programs
                  .Include(u => u.BatchList).Where(u=>u.Id==Id)
                  .Select(b =>
                      new
                      {
                          Id = b.Id,
                          ProgramName = b.ProgramName,
                          BatchList = b.BatchList.Select(x =>
                          new
                          {
                              BatchId = x.Id,
                              BatchName = x.BatchName,
                          }
                          ).ToList()
                      }).ToListAsync();
            return batchList;
        }

        public async Task UpdateBatchProgramAsync(int Id ,BatchProgram batchProgram)
        {
            _context.Programs.Update(batchProgram);
        }
        public async Task<object> GetBatchCount(int Id)
        {
            var count = _context.Programs.Include(u => u.BatchList) .Where(u=>u.Id==Id).Select(u => new
            {
                BatchCount = u.BatchList.Count()
            });
            return count;
        }
    }
}
