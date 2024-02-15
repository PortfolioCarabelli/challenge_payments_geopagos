using AuthorizationService.DTOs;
using AuthorizationService.Models;
using AuthorizationService.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ConfirmationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConfirmationController : Controller
    {
        private readonly IConfirmationRepository _repository;

        private readonly IMapper _mapper;

        public ConfirmationController(IConfirmationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] ConfirmationRequestDTO confirmationRequestDTO)
        {
            try
            {
                var confirmationRequest = _mapper.Map<ConfirmationRequest>(confirmationRequestDTO);
                await _repository.AddConfirmationRequestAsync(confirmationRequest);
                return Ok("Confirmation request created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while confirming the request: {ex.Message}");
            }
        }
    }
}
