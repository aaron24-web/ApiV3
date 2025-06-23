// Dtos/HistorialCalculoDTO.cs
using System;

namespace JaveragesLibrary.Dtos
{
    public class HistorialCalculoDTO
    {
        public long Id { get; set; }
        public string? TipoOperacion { get; set; }
        public string? Inputs { get; set; }
        public double? Resultado { get; set; }
        public DateTimeOffset FechaOperacion { get; set; }
    }
}