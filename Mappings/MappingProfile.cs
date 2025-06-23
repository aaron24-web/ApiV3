// Mappings/MappingProfile.cs
using AutoMapper;
using JaveragesLibrary.Dtos;
using JaveragesLibrary.Entities;

namespace JaveragesLibrary.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Regla de mapeo: De la entidad HistorialCalculo al DTO HistorialCalculoDTO
            CreateMap<HistorialCalculo, HistorialCalculoDTO>();
        }
    }
}