using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;

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
            return this._context.BatchPhase;
        }
        public async Task AddNewBatchPhase(BatchPhase batchPhase)
        {
            _context.BatchPhase.Add(batchPhase);
            await _context.SaveChangesAsync();

        }

    }
}
