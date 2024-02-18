using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence.DTOs;
using Persistence.Models;
using ReportingService.Services.Contracts;

namespace ReportingService.Controllers
{
    public class ReportingController : Controller
    {
        private readonly IReportingRepository _reportingRepository;
        private readonly IMapper _mapper;
        public ReportingController(IReportingRepository reportingRepository, IMapper mapper)
        {
            _reportingRepository = reportingRepository;
            _mapper = mapper;
        }

        [HttpGet("approved-authorizations")]
        public async Task<ActionResult<IEnumerable<ReportDTO>>> GetApprovedAuthorizations()
        {
            var approvedAuthorizations = await _reportingRepository.GetApprovedAuthorizationsAsync();
            return Ok(approvedAuthorizations);
        }

      
    }
}
