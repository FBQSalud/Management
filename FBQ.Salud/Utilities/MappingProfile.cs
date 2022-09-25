using AutoMapper;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Presentation.Utilities
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Documentos, DocumentosDto>().ReverseMap();
            CreateMap<Insumos, InsumosDto>().ReverseMap();
        }
       
    }
}
