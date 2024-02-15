using AuthorizationService.DTOs;
using AuthorizationService.Models;
using AuthorizationService.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository _repository;
        private readonly IMapper _mapper;

        public AuthorizationController(IAuthorizationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("authorize")]
        public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizationRequestDTO authorizationRequestDTO)
        {
            try
            {
                var authorizationRequest = _mapper.Map<AuthorizationRequest>(authorizationRequestDTO);
                await _repository.AddAuthorizationRequestAsync(authorizationRequest);
                return Ok("Authorization request created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while authorizing the request: {ex.Message}");
            }
        }

        [HttpGet("authorization-requests")]
        public async Task<IActionResult> GetAllAuthorizationRequestsAsync()
        {
            try
            {
                var authorizationRequests = await _repository.GetAllAuthorizationRequestsAsync();
                var authorizationRequestDTOs = _mapper.Map<IEnumerable<AuthorizationRequestDTO>>(authorizationRequests);
                return Ok(authorizationRequestDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving authorization requests: {ex.Message}");
            }
        }
    }
}
