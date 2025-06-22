// JaveragesLibrary/Controllers/V1/GeometryController.cs
using JaveragesLibrary.Services.Features.Geometry;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JaveragesLibrary.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class GeometryController : ControllerBase
    {
        private readonly GeometryCalculationService _geometryService;

        public GeometryController(GeometryCalculationService geometryService)
        {
            _geometryService = geometryService;
        }

        [HttpGet("rectangleArea")]
        public async Task<IActionResult> GetRectangleAreaAsync([FromQuery] double width, [FromQuery] double height)
        {
            if (width <= 0 || height <= 0)
            {
                return BadRequest(new { Message = "Width and height must be positive values." });
            }

            try
            {
                // Ahora esperamos que el método del servicio también sea asíncrono
                double area = await _geometryService.CalculateRectangleAreaAsync(width, height);
                return Ok(new { Shape = "Rectangle", Width = width, Height = height, Area = area });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("cubeVolume")]
        public async Task<IActionResult> GetCubeVolumeAsync([FromQuery] double sideLength)
        {
            if (sideLength <= 0)
            {
                return BadRequest(new { Message = "Side length must be a positive value." });
            }

            try
            {
                double volume = await _geometryService.CalculateCubeVolumeAsync(sideLength);
                return Ok(new { Shape = "Cube", SideLength = sideLength, Volume = volume });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("cylinderVolume")]
        public async Task<IActionResult> GetCylinderVolumeAsync([FromQuery] double radius, [FromQuery] double height)
        {
            if (radius <= 0 || height <= 0)
            {
                return BadRequest(new { Message = "Radius and height must be positive values." });
            }

            try
            {
                double volume = await _geometryService.CalculateCylinderVolumeAsync(radius, height);
                return Ok(new { Shape = "Cylinder", Radius = radius, Height = height, Volume = volume });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}