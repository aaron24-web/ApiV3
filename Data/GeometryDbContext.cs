// Data/GeometryDbContext.cs
using JaveragesLibrary.Entities; // Asegúrate que apunte a tu nueva carpeta Entities
using Microsoft.EntityFrameworkCore;

// El namespace puede variar. Ajústalo si es necesario.
namespace JaveragesLibrary.Data 
{
    public class GeometryDbContext : DbContext
    {
        public GeometryDbContext(DbContextOptions<GeometryDbContext> options) : base(options)
        {
        }

        // Le decimos al DbContext que nuestra base de datos tiene una tabla de "HistorialCalculos"
        public DbSet<HistorialCalculo> HistorialCalculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuramos el mapeo entre la clase C# y la tabla de la base de datos
            modelBuilder.Entity<HistorialCalculo>(entity =>
{
    entity.ToTable("historial_calculos");

    entity.Property(e => e.Id).HasColumnName("id");
    entity.Property(e => e.TipoOperacion).HasColumnName("tipo_operacion");
    entity.Property(e => e.Inputs).HasColumnName("inputs");
    entity.Property(e => e.Resultado).HasColumnName("resultado");
    
    // VVV AÑADE ESTA CONFIGURACIÓN PARA LA FECHA VVV
    entity.Property(e => e.FechaOperacion)
          .HasColumnName("fecha_operacion")
          .ValueGeneratedOnAdd(); // <-- Le dice a EF que la DB genera este valor al insertar
});
        }
    }
}