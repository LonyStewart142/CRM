using AutoMapper;
using CRM.Application.DTOs;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Application.Mappings
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles() 
        {
           //Cliente
           CreateMap<Cliente,ClienteDTO>().ReverseMap();
           CreateMap<Cliente, CreatedDTO>();
           //Ejecutivo
           CreateMap<Ejecutivo, EjecutivoDTO>().ReverseMap();
           CreateMap<Ejecutivo, CreatedDTO>();
           //Venta
           CreateMap<Venta, VentaDTO>().ReverseMap();
           CreateMap<Venta, CreatedDTO>();
           //Visita
           CreateMap<Visita, VisitaDTO>().ReverseMap();
           CreateMap<Visita, CreatedDTO>();
        }
    }
}
