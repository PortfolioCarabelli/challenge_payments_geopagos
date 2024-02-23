using AuthorizationService.Services.Contracts;
using AutoMapper;
using ConfirmationService.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.DTOs;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly PaymentProcessorClient _paymentProcessorClient;

        public AuthorizationController(IAuthorizationRepository repository, IMapper mapper, PaymentProcessorClient paymentProcessorClient)
        {
            _repository = repository;
            _mapper = mapper;
            _paymentProcessorClient = paymentProcessorClient;
        }

        [HttpPost("authorize")]
        public async Task<IActionResult> AuthorizePayment([FromBody] AuthorizationRequestDTO requestDTO)
        {
            try
            {
        
                var requestModel = _mapper.Map<AuthorizationRequestDTO, AuthorizationRequest>(requestDTO);

             
                var response = await _repository.AuthorizePayment(requestModel);

                bool isApproved = await _paymentProcessorClient.IsPaymentApproved(response.Id);

                if (isApproved)
                {
                    response.Status = "approved";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Message = "An error occurred while processing the request.", Error = ex.Message });
            }
        }


        [HttpGet("authorizeGet")]
        public async Task GetAuthorizePayment()
        {
            Console.WriteLine("Hola entre piola");
        }
    }
}