using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Context;
using Microsoft.EntityFrameworkCore;

namespace ComunicacionesPsicologia.Repository
{
    public interface IConversacionRepository
    {
        Task<Conversacion> GetConversacionByIdAsync(int id);
        Task<Conversacion> AddAsync(Conversacion conversacion);
    }
    public class ConversacionRepository : IConversacionRepository
    {
        private readonly CPContext _context;
        public ConversacionRepository(CPContext context)
        {
            _context = context;
        }
        public async Task<Conversacion> GetConversacionByIdAsync(int id)
        {
            return await _context.Conversaciones
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.IdConversacion == id);
        }
        public async Task<Conversacion> AddAsync(Conversacion conversacion)
        {
            await _context.Conversaciones.AddAsync(conversacion);
            await _context.SaveChangesAsync();
            return conversacion;
        }
    }
}
