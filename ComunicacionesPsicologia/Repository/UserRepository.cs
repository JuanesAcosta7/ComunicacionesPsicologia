using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Context;
using Microsoft.EntityFrameworkCore;

namespace ComunicacionesPsicologia.Repository
{
    public interface IUserRepository
    {
        Task<Users> GetUserByIdAsync(int id);
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly CPContext _context;
        public UserRepository(CPContext context)
        {
            _context = context;
        }
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task AddUserAsync(Users user)
        {
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(Users user)
        {
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
