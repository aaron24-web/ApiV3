// Services/Features/Historial/HistorialService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using JaveragesLibrary.Entities;
using JaveragesLibrary.Repositories;

namespace JaveragesLibrary.Services.Features.Historial
{
    public class HistorialService
    {
        private readonly HistorialRepository _historialRepository;

        public HistorialService(HistorialRepository historialRepository)
        {
            _historialRepository = historialRepository;
        }

        public async Task<IEnumerable<HistorialCalculo>> GetAllAsync()
        {
            return await _historialRepository.GetAllAsync();
        }
    }
}