using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Repository;

namespace ComunicacionesPsicologia.Services
{
    public interface IRecursosService
    {
        Task<Recursos> GetRecursoByIdAsync(int id);
        Task<List<Recursos>> GetAllRecursosAsync();
        Task AddRecursoAsync(Recursos recurso);
        Task UpdateRecursoAsync(Recursos recurso);
        Task DeleteRecursoAsync(int id);
    }

    public class RecursosService : IRecursosService
    {
        private readonly IRecursosRepository _recursosRepository;
        public RecursosService(IRecursosRepository recursosRepository)
        {
            _recursosRepository = recursosRepository;
        }
        public async Task<Recursos> GetRecursoByIdAsync(int id)
        {
            return await _recursosRepository.GetRecursoByIdAsync(id);
        }
        public async Task<List<Recursos>> GetAllRecursosAsync()
        {
            return await _recursosRepository.GetAllRecursosAsync();
        }
        public async Task AddRecursoAsync(Recursos recurso)
        {
            await _recursosRepository.AddRecursoAsync(recurso);
        }
        public async Task UpdateRecursoAsync(Recursos recurso)
        {
            await _recursosRepository.UpdateRecursoAsync(recurso);
        }
        public async Task DeleteRecursoAsync(int id)
        {
            await _recursosRepository.DeleteRecursoAsync(id);
        }
    }
}
