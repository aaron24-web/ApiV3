// JaveragesLibrary/Controllers/V1/GeometryController.cs
using JaveragesLibrary.Services.Features.Geometry; // Necesitamos nuestro servicio de cálculo
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")] // Ruta base: api/v1/geometry
public class GeometryController : ControllerBase
{
    private readonly AreaCalculationService _areaService;

    public GeometryController(AreaCalculationService areaService)
    {
        _areaService = areaService;
    }

    // GET api/v1/geometry/rectangleArea?width=NUMERO&height=NUMERO
    [HttpGet("rectangleArea")]
    public IActionResult GetRectangleArea([FromQuery] double width, [FromQuery] double height)
    {
        if (width <= 0 || height <= 0)
        {
            // Podrías manejar esto aquí o dejar que el servicio lance la excepción
            // y luego usar un middleware de manejo de excepciones.
            return BadRequest(new { Message = "Width and height must be positive values." });
        }

        try
        {
            double area = _areaService.CalculateRectangleArea(width, height);
            return Ok(new { Shape = "Rectangle", Width = width, Height = height, Area = area });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    // Aquí podrías añadir más endpoints para otras figuras
    // [HttpGet("circleArea")]
    // public IActionResult GetCircleArea([FromQuery] double radius) { ... }
}