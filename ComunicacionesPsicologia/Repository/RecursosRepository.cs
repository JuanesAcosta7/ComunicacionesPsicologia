using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Context;
using Microsoft.EntityFrameworkCore;

namespace ComunicacionesPsicologia.Repository
{
    public interface IRecursosRepository
    {
        Task<Recursos> GetRecursoByIdAsync(int id);
        Task<List<Recursos>> GetAllRecursosAsync();
        Task AddRecursoAsync(Recursos recurso);
        Task UpdateRecursoAsync(Recursos recurso);
        Task DeleteRecursoAsync(int id);
    }

    public class RecursosRepository : IRecursosRepository
    {
        private readonly CPContext _context;
        public RecursosRepository(CPContext context)
        {
            _context = context;
        }
        public async Task<Recursos> GetRecursoByIdAsync(int id)
        {
            return await _context.Recursos.FindAsync(id);
        }
        public async Task<List<Recursos>> GetAllRecursosAsync()
        {
            return await _context.Recursos.ToListAsync();
        }
        public async Task AddRecursoAsync(Recursos recurso)
        {
            await _context.Recursos.AddAsync(recurso);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRecursoAsync(Recursos recurso)
        {
            _context.Recursos.Update(recurso);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRecursoAsync(int id)
        {
            var recurso = await GetRecursoByIdAsync(id);
            if (recurso != null)
            {
                _context.Recursos.Remove(recurso);
                await _context.SaveChangesAsync();
            }
        }
    }
