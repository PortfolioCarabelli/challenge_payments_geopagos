using AuthorizationService.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Models;
using System.Net;

namespace AuthorizationService.Services.Implementation
{
    public class ConfirmationRepository : IConfirmationRepository
    {

        private readonly AplicationDbContext _context;

        public ConfirmationRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApprovedAuthorization> ConfirmAuthorization(int AutorizationId)
        {
            try
            {
                // Obtener la autorización correspondiente a la solicitud
                AuthorizationRequest authorization = await _context.AuthorizationRequests.FindAsync(AutorizationId);

                // Verificar si la autorización existe y no ha sido confirmada
                if (authorization != null)
                {
                    bool isApproved = IsPaymentApproved(authorization.Amount);
                    if (isApproved)
                    {
                        // Confirmar la autorización
                        authorization.Status = "approved";

                        // Actualizar la autorización en la base de datos
                        _context.Update(authorization);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        authorization.Status = "denied";

                        // Actualizar la autorización en la base de datos
                        _context.Update(authorization);
                        await _context.SaveChangesAsync();
                    }

                }

                //HAce el guardado del ApprovedAuthorization
                var approvedRequest = new ApprovedAuthorization { 
                    RequestId = AutorizationId,
                    Amount=authorization.Amount,
                    ClientId = authorization.ClientId,
                };
                _context.ApprovedAuthorizations.Add(approvedRequest);
                await _context.SaveChangesAsync();

                //HAce el guardado del Report
                AddReport(authorization);


                return approvedRequest;
            }
            catch (Exception ex)
            {
                // Manejar errores
                throw new Exception("An error occurred while confirming the authorization.", ex);
            }
        }

        private bool IsPaymentApproved(decimal amount)
        {
            // Devuelve true si el monto es un número entero y false si contiene decimales
            return amount == Math.Floor(amount);
        }

        private async void AddReport(AuthorizationRequest authorizationRequest)
        {
            // Devuelve true si el monto es un número entero y false si contiene decimales
            var approvedRequest = new Report
            {
                Amount = authorizationRequest.Amount,
                ClientId = authorizationRequest.ClientId,
            };
            _context.Reports.Add(approvedRequest);
            await _context.SaveChangesAsync();
           
        }

    }
}
