using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class PhaseRepository : IPhaseRepository
    {
        private ApiContext _context;
        public PhaseRepository(ApiContext _context) { 
            this._context = _context;
        }
        public async Task<IEnumerable<Phase>> GetAllPhasesAsync()
        {
            return this._context.Phases;
        }
        public async Task AddNewPhase(Phase phase)
        {
            _context.Phases.Add(phase);
            await this._context.SaveChangesAsync();
        }

        public async Task DeletePhase(int id)
        {
            _context.Phases.Remove(_context.Phases.Find(id));
            _context.SaveChanges();
        }

    }
}
