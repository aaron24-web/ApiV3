// Entities/HistorialCalculo.cs
using System;

// El namespace puede variar según el nombre de tu proyecto. Ajústalo si es necesario.
namespace JaveragesLibrary.Entities 
{
    public class HistorialCalculo
    {
        public long Id { get; set; }
        public string? TipoOperacion { get; set; }
        public string? Inputs { get; set; }
        public double? Resultado { get; set; }
        public DateTimeOffset FechaOperacion { get; set; }
    }
}