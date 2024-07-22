using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class BatchPhaseRepository:IBatchPhaseRepository
    {
        private ApiContext _context;
        private IMapper _mapper;
        public BatchPhaseRepository(ApiContext _context,IMapper _mapper)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<BatchPhase>> GetAllBatchPhasesAsync()
        {
            return this._context.BatchPhase.Include(u=>u.Phase);
        }
        public async Task<int> AddNewBatchPhase(BatchPhase batchPhase)
        {
            _context.BatchPhase.Add(batchPhase);
            await _context.SaveChangesAsync();
            return batchPhase.Id;
        }

    }
}
