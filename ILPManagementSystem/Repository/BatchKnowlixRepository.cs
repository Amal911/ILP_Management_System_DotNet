using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository
{
    
    public class BatchKnowlixRepository : IBatchKnowlixRepository
    {
        private readonly ApiContext _context;
        private readonly IBatchKnowlixRepository _batchKnowlixRepository;
        private readonly IMapper _mapper;

        public BatchKnowlixRepository(ApiContext context)
        {
            this._context = context;
        }

         public async Task <IEnumerable<BatchKnowlixDTO>> GetAllAsync()
        {
            return await _context.Batchs
        .Select(batch => new BatchKnowlixDTO
        {
            Id = batch.Id,
            BatchName = batch.BatchName
        })
        .ToListAsync();
        }
    }
}
