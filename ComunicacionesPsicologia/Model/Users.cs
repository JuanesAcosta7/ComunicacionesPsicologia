namespace ComunicacionesPsicologia.Model
{
    public enum Rol
    {
        Admin =0,
        User = 1
    }
    public class Users
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; } = Rol.User;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public ICollection<Conversacion> Conversaciones { get; set; }
    }
}
