using ConfirmationService.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence.DTOs;
using Persistence.Models;

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

        [HttpPost("confirm/{AuthorizationId}")]
        public async Task<IActionResult> ConfirmAuthorization(int AuthorizationId)
        {
            try
            {
                var isApproved = await _repository.ConfirmAuthorization(AuthorizationId);

                if (isApproved != null)
                {
                    return Ok("Authorization confirmed successfully.");
                }
                else
                {
                    return BadRequest("Authorization confirmation failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al confirmar la autorización");
            }
        }
    }
}
