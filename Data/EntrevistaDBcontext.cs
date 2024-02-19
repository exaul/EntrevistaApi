using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TareaAPiXD.Models;

namespace TareaAPiXD.Data
{
    public class EntrevistaDBcontext : DbContext
    {
        public EntrevistaDBcontext(DbContextOptions<EntrevistaDBcontext> options):base (options)
        {

        }
        public DbSet <Entrevistado> entrevistados { get; set; }
        public DbSet <Entrevistador> entrevistadores { get; set; }
        public DbSet<Hojadevida> hojadevidas { get; set; }

        public DbSet<DetalleEntrevistador> detalleEntrevistadores { get; set; }
        public DbSet<DetalleHojadevida> detalleHojadevidas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entrevistado1 = new Entrevistado() { Id = 1, NombreDelEntrevistador = "Edwin", Hojadevida = "aceptada", Area = "desarrollador junior", Activo = true };
            var entrevistador1 = new Entrevistador() { Id = 1, NombreDelEntrevistador = "Edwin", edad = 22, Activo = true };
            var hojadevida1 = new Hojadevida() {  Id = 1,departamento="Programadores", Disponible= true };
            var detalleEntrevista1 = new DetalleEntrevistador() { Id = 1, EntrevistadoId = 1, HojadevidaId = 1};
            var detallehojadevida1 = new DetalleHojadevida() { Id = 1, EntrevistadoId = 1, HojadevidaId = 1};
            modelBuilder.Entity<Entrevistado>().HasData(new Entrevistado[] { entrevistado1 });
            modelBuilder.Entity<Entrevistador>().HasData(new Entrevistador[] { entrevistador1 });
            modelBuilder.Entity<Hojadevida>().HasData(new Hojadevida[] { hojadevida1 });
            modelBuilder.Entity<DetalleEntrevistador>().HasData(new DetalleEntrevistador[] { detalleEntrevista1 });
            modelBuilder.Entity<DetalleHojadevida>().HasData(new DetalleHojadevida[] { detallehojadevida1 });
        }
    }
  
}
