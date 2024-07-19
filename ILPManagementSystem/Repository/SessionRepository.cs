using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private ApiContext _context;
        public SessionRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Session>> GetAllAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task CreateAsync(Session session)
        {
            _context.Sessions.Add(session);
        }

        public async Task<Session> GetAsync(int id)
        {
            return await _context.Sessions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task RemoveAsync(Session session)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public Task UpdateAsync(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
