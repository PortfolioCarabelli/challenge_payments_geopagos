using AuthorizationService.DTOs;
using AuthorizationService.Models;
using AutoMapper;

using System.Globalization;

namespace AuthorizationService.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ConfirmationRequest, ConfirmationRequestDTO>().ReverseMap();
        }
    }
}
