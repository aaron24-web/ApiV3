// JaveragesLibrary/Services/Features/Geometry/GeometryCalculationService.cs
using System;
using System.Threading.Tasks; // <-- Se añade este using

namespace JaveragesLibrary.Services.Features.Geometry
{
    public class GeometryCalculationService
    {
        // Se cambia el retorno de 'double' a 'Task<double>' y se añade el sufijo 'Async'
        public Task<double> CalculateRectangleAreaAsync(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be positive values.");
            }
            double area = width * height;
            // Se envuelve el resultado en una tarea completada
            return Task.FromResult(area);
        }

        public Task<double> CalculateCubeVolumeAsync(double sideLength)
        {
            if (sideLength <= 0)
            {
                throw new ArgumentException("Side length must be a positive value.");
            }
            double volume = Math.Pow(sideLength, 3);
            return Task.FromResult(volume);
        }

        public Task<double> CalculateCylinderVolumeAsync(double radius, double height)
        {
            if (radius <= 0 || height <= 0)
            {
                throw new ArgumentException("Radius and height must be positive values.");
            }
            double volume = Math.PI * Math.Pow(radius, 2) * height;
            return Task.FromResult(volume);
        }
    }
}