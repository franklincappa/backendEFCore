using AutoMapper;
using EFCoreWebApi.DTOs;
using EFCoreWebApi.Entidades;

namespace EFCoreWebApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
        }
    }
}
