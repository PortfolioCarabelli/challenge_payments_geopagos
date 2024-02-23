using AutoMapper;
using Persistence.DTOs;
using Persistence.Models;
using System.Globalization;

namespace ConfirmationService.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApprovedAuthorization, ApprovedAuthorizationDTO>().ReverseMap();
        }
    }
}
