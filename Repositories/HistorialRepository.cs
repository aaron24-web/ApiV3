// Repositories/HistorialRepository.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Data;
using JaveragesLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Repositories
{
    public class HistorialRepository
    {
        private readonly GeometryDbContext _context;

        public HistorialRepository(GeometryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialCalculo>> GetAllAsync()
        {
            // Devolvemos el historial ordenado por el más reciente primero
            return await _context.HistorialCalculos
                .OrderByDescending(h => h.FechaOperacion)
                .ToListAsync();
        }
    }
}