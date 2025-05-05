using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Repository;

namespace ComunicacionesPsicologia.Services
{
    public interface IConversationService
    {
        Task<Conversacion> GetConversacionByIdAsync(int id);
        Task<Conversacion> AddConversacionAsync(Conversacion conversacion);
    }

    public class ConversationService : IConversationService
    {
        private readonly IConversacionRepository _conversacionRepository;
        public ConversationService(IConversacionRepository conversacionRepository)
        {
            _conversacionRepository = conversacionRepository;
        }
        public async Task<Conversacion> GetConversacionByIdAsync(int id)
        {
            return await _conversacionRepository.GetConversacionByIdAsync(id);
        }
        public async Task<Conversacion> AddConversacionAsync(Conversacion conversacion)
        {
            return await _conversacionRepository.AddAsync(conversacion);
        }
    }
}
