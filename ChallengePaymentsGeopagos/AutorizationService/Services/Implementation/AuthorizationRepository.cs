using AuthorizationService.Services.Contracts;
using ConfirmationService.Utilities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.DTOs;
using Persistence.Models;

namespace AuthorizationService.Services.Implementation
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly AplicationDbContext _context;
   

        public AuthorizationRepository(AplicationDbContext context)
        {
            _context = context;
          
        }

        public async Task<AuthorizationRequest> AuthorizePayment(AuthorizationRequest authorizationRequest)
        {
            try
            {
                // Validar la solicitud de autorización
                if (!IsPaymentRequestValid(authorizationRequest))
                {
                    return new AuthorizationRequest { Status = "Error"};
                }

                // Actualizar el estado de la solicitud en la base de datos
                authorizationRequest.Status = "pending";
                await _context.AuthorizationRequests.AddAsync(authorizationRequest);
                await _context.SaveChangesAsync();

                // Devolver la respuesta de autorización
                return authorizationRequest;
            }
            catch (Exception ex)
            {
                // Manejar errores
                return new AuthorizationRequest { Status = "error"};
            }
        }

        private bool IsPaymentRequestValid(AuthorizationRequest authorizationRequest)
        {
            return authorizationRequest.Amount > 0 && authorizationRequest.ClientId != null;
        }

    
    }
}
