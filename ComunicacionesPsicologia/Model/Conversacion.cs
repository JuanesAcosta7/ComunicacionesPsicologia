namespace ComunicacionesPsicologia.Model
{
    public class Conversacion
    {
        public int IdConversacion { get; set; }
        public string MensajeUsuario { get; set; }
        public string RespuestaBot { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Clave foránea
        public int IdUsuario { get; set; }
        public Users Usuario { get; set; }
    }
}
