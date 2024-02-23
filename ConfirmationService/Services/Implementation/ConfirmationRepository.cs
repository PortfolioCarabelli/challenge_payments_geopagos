using ConfirmationService.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Models;
using System.Net;

namespace ConfirmationService.Services.Implementation
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
                AuthorizationRequest authorization = await _context.AuthorizationRequests.FindAsync(AutorizationId);

                if (authorization != null)
                {
                    bool isApproved = IsPaymentApproved(authorization.Amount);
                    if (isApproved)
                    {
                        authorization.Status = "approved";

                        _context.Update(authorization);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        authorization.Status = "denied";

                        _context.Update(authorization);
                        await _context.SaveChangesAsync();
                    }

                }

                var approvedRequest = new ApprovedAuthorization { 
                    RequestId = AutorizationId,
                    Amount=authorization.Amount,
                    ClientId = authorization.ClientId,
                };
                _context.ApprovedAuthorizations.Add(approvedRequest);
                await _context.SaveChangesAsync();

                AddReport(authorization);


                return approvedRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while confirming the authorization.", ex);
            }
        }

        private bool IsPaymentApproved(decimal amount)
        {
            return amount == Math.Floor(amount);
        }

        private async void AddReport(AuthorizationRequest authorizationRequest)
        {
            var approvedRequest = new Report
            {
                Date = (DateTime)authorizationRequest.RequestDate,
                Amount = authorizationRequest.Amount,
                ClientId = authorizationRequest.ClientId,
            };
            _context.Reports.Add(approvedRequest);
            await _context.SaveChangesAsync();
           
        }

    }
}
