using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class ExposedBatchRepository : IExposedBatchRepository
    {
        private readonly ApiContext _context;
        public ExposedBatchRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ExposedBatchDTO>> GetAllAsync()
        {
            return await _context.Batchs
        .Select(batch => new ExposedBatchDTO
        {
            Id = batch.Id,
            BatchName = batch.BatchName
        })
        .ToListAsync();
        }
    }
}
