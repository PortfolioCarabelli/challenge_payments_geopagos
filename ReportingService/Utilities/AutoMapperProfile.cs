using AutoMapper;
using Persistence.DTOs;
using Persistence.Models;
using System.Globalization;

namespace ReportingService.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApprovedAuthorization, ApprovedAuthorizationDTO>().ReverseMap();
        }
    }
}
