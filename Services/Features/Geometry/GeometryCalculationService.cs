// Services/Features/Geometry/GeometryCalculationService.cs

using JaveragesLibrary.Data;       // <-- Using para el DbContext
using JaveragesLibrary.Entities;  // <-- Using para la Entidad
using System;
using System.Threading.Tasks;

namespace JaveragesLibrary.Services.Features.Geometry
{
    public class GeometryCalculationService
    {
        // --- CAMBIO 1: Añadir el DbContext ---
        private readonly GeometryDbContext _context;

        // El constructor ahora recibe el DbContext a través de la inyección de dependencias
        public GeometryCalculationService(GeometryDbContext context)
        {
            _context = context;
        }

        public async Task<double> CalculateRectangleAreaAsync(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be positive values.");
            }
            
            double area = width * height;

            // --- CAMBIO 2: Lógica para guardar el historial ---
            var historial = new HistorialCalculo
            {
                TipoOperacion = "Area Rectangulo",
                Inputs = $"width={width}, height={height}",
                Resultado = area
                // La fecha se añade automáticamente por la base de datos
            };
            
            await _context.HistorialCalculos.AddAsync(historial);
            await _context.SaveChangesAsync(); // Guarda el registro en la base de datos
            // --- FIN DEL CAMBIO ---

            return area;
        }

        public async Task<double> CalculateCubeVolumeAsync(double sideLength)
        {
            if (sideLength <= 0)
            {
                throw new ArgumentException("Side length must be a positive value.");
            }

            double volume = Math.Pow(sideLength, 3);

            var historial = new HistorialCalculo
            {
                TipoOperacion = "Volumen Cubo",
                Inputs = $"sideLength={sideLength}",
                Resultado = volume
            };

            await _context.HistorialCalculos.AddAsync(historial);
            await _context.SaveChangesAsync();

            return volume;
        }

        public async Task<double> CalculateCylinderVolumeAsync(double radius, double height)
        {
            if (radius <= 0 || height <= 0)
            {
                throw new ArgumentException("Radius and height must be positive values.");
            }

            double volume = Math.PI * Math.Pow(radius, 2) * height;

            var historial = new HistorialCalculo
            {
                TipoOperacion = "Volumen Cilindro",
                Inputs = $"radius={radius}, height={height}",
                Resultado = volume
            };
            
            await _context.HistorialCalculos.AddAsync(historial);
            await _context.SaveChangesAsync();

            return volume;
        }
    }
}