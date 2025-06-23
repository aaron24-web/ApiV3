// Controllers/V1/HistorialController.cs
using AutoMapper;
using JaveragesLibrary.Dtos;
using JaveragesLibrary.Services.Features.Historial;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JaveragesLibrary.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class HistorialController : ControllerBase
    {
        private readonly HistorialService _historialService;
        private readonly IMapper _mapper;

        public HistorialController(HistorialService historialService, IMapper mapper)
        {
            _historialService = historialService;
            _mapper = mapper;
        }

        // Este endpoint devolverá todo el historial de cálculos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historial = await _historialService.GetAllAsync();
            var historialDto = _mapper.Map<IEnumerable<HistorialCalculoDTO>>(historial);
            return Ok(historialDto);
        }
    }
}