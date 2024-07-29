using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private ApiContext _context;
        private IMapper _mapper;
        public SessionRepository(ApiContext context, IMapper _mapper)
        {
            this._context = context;
            this._mapper = _mapper;
        }

        public async Task<ICollection<SessionDTO>> GetAllAsync()
        {
            List<Session>sessions =  await _context.Sessions.ToListAsync();
            List<SessionDTO> res = new List<SessionDTO>();
            foreach (var session in sessions)
            {
                User trainer = await _context.Users.FirstOrDefaultAsync(u => u.Id == session.TrainerId);
                SessionDTO sessionDTO = _mapper.Map<SessionDTO>(session);
                sessionDTO.TrainerName = $"{trainer.FirstName} {trainer.LastName}";
                res.Add(sessionDTO);
            }
            return res;
        }

        public async Task CreateAsync(Session session)
        {
            _context.Sessions.Add(session);
        }

        public async Task<Session> GetAsync(int id)
        {
            return await _context.Sessions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<SessionDTO> GetSessionDetails(int id)
        {
            Session sessionData = await _context.Sessions.FirstOrDefaultAsync(u=>u.Id==id);
            User trainer = await _context.Users.FirstOrDefaultAsync(u=>u.Id== sessionData.TrainerId);
            SessionDTO session = _mapper.Map<SessionDTO>(sessionData);
            session.TrainerName = $"{trainer.FirstName} {trainer.LastName}";
            return session;
        }

        public Task RemoveAsync(Session session)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task UpdateAsync(Session session)
        {
            _context.Update(session);
            await _context.SaveChangesAsync();
        }
    }
}
