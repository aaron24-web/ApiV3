// JaveragesLibrary/Services/Features/Geometry/AreaCalculationService.cs
namespace JaveragesLibrary.Services.Features.Geometry;

public class AreaCalculationService
{
    public double CalculateRectangleArea(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Width and height must be positive values.");
        }
        return width * height;
    }

    // Aquí podríamos añadir más métodos para otras figuras (círculo, triángulo, etc.)
    // public double CalculateCircleArea(double radius) { ... }
}