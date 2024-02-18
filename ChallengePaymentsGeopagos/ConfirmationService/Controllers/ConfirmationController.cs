using AuthorizationService.Services.Contracts;
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
                // Verificar si el monto es aprobado por el procesador de pago
                var isApproved = await _repository.ConfirmAuthorization(AuthorizationId);

                if (isApproved != null)
                {
                    // La autorización fue confirmada exitosamente
                    // Aquí puedes realizar cualquier lógica adicional necesaria
                    return Ok("Authorization confirmed successfully.");
                }
                else
                {
                    // La autorización no fue confirmada
                    // Aquí puedes realizar cualquier lógica adicional necesaria
                    return BadRequest("Authorization confirmation failed.");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                return StatusCode(500, "Error al confirmar la autorización");
            }
        }
    }
}
