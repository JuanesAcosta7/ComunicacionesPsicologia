using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Repository;

namespace ComunicacionesPsicologia.Services
{
    public interface IUserService
    {

        Task<Users> GetUserByIdAsync(int id);
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task AddUserAsync(Users user)
        {
            await _userRepository.AddUserAsync(user);
        }
        public async Task UpdateUserAsync(Users user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
