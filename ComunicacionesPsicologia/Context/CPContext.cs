using ComunicacionesPsicologia.Model;
using Microsoft.EntityFrameworkCore;

namespace ComunicacionesPsicologia.Context
{
    public class CPContext : DbContext
    {

     public CPContext(DbContextOptions<CPContext> options) : base(options)
        {
        }

        public DbSet<Users> Usuarios { get; set; }
        public DbSet<Conversacion> Conversaciones { get; set; }
        public DbSet<Recursos> Recursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones
            modelBuilder.Entity<Conversacion>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Conversaciones)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un usuario, se eliminan sus conversaciones

            // Configuración opcional para nombres personalizados de tabla
            modelBuilder.Entity<Users>().ToTable("Usuarios");
            modelBuilder.Entity<Conversacion>().ToTable("Conversaciones");
            modelBuilder.Entity<Recursos>().ToTable("Recursos");
        }
    }
}
