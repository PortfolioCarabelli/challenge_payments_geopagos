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
                // Valida la solicitud de autorización
                if (!IsPaymentRequestValid(authorizationRequest))
                {
                    return new AuthorizationRequest { Status = "Error"};
                }

                // Actualizar el estado de la solicitud
                authorizationRequest.Status = "pending";
                await _context.AuthorizationRequests.AddAsync(authorizationRequest);
                await _context.SaveChangesAsync();

         
                return authorizationRequest;
            }
            catch (Exception ex)
            {
                return new AuthorizationRequest { Status = "error"};
            }
        }

        public async Task<List<AuthorizationRequest>> GetPendingAuthorizationsAsync()
        {
            return await _context.AuthorizationRequests
                .Where(a => a.Status == "pending" && a.Client.ClientType == "Second")
                .ToListAsync();
        }


        public async Task ReverseAuthorizationAsync(AuthorizationRequest authorizationRequest)
        {
            try
            {
                // Actualizar el estado de la autorización a revertida
                authorizationRequest.AuthorizationType = "reversal";
                authorizationRequest.Status = "denied";
                _context.Update(authorizationRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new AuthorizationRequest { Status = "error" };
            }
        }

        private bool IsPaymentRequestValid(AuthorizationRequest authorizationRequest)
        {
            return authorizationRequest.Amount > 0 && authorizationRequest.ClientId != null;
        }

    
    }
}
