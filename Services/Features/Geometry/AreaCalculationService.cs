// JaveragesLibrary/Services/Features/Geometry/GeometryCalculationService.cs
namespace JaveragesLibrary.Services.Features.Geometry;

public class GeometryCalculationService
{
    public double CalculateRectangleArea(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Width and height must be positive values.");
        }
        return width * height;
    }

    public double CalculateCubeVolume(double sideLength)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentException("Side length must be a positive value.");
        }
        return Math.Pow(sideLength, 3);
    }

    public double CalculateCylinderVolume(double radius, double height)
    {
        if (radius <= 0 || height <= 0)
        {
            throw new ArgumentException("Radius and height must be positive values.");
        }
        return Math.PI * Math.Pow(radius, 2) * height;
    }
}