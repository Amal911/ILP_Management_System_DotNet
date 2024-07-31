using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext _context;

        public UserRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
            /*return await _context.Users.ToListAsync();*/
        }
        public async Task<IEnumerable<User>> GetAllUserData()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u=>u.Id==id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            if (user.RoleId == 1)
            {
                _context.Admin.Add(new Admin { UserId = user.Id });
                _context.SaveChanges();
            }
            else if (user.RoleId == 2)
            {
                _context.Trainers.Add(new Trainer { userId = user.Id });
            }
          /*  else if (user.RoleId == 3)
            {
                _context.Trainees.Add(new Trainee { UserId = user.Id });
            }*/

            return user;
            
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        /*public async Task<object> GetTrainers()
        {
            return await this._context.Users.Include(u => u.Role).ToListAsync();
        }*/
        public async Task<IEnumerable<TrainerDetailsDTO>> GetTrainers()
        {
            return await _context.Users.Where(u=>u.RoleId==2).Include(u => u.Role)
                .Select(u=>
                new TrainerDetailsDTO
                {
                    Id = u.Id,
                    TrainerId = u.TrainerId,
                    Name = $"{u.FirstName} {u.LastName}",
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    MobileNumber = u.MobileNumber,
                    Email = u.EmailId,

                }
                )
                .ToListAsync();
        }
    }
}
