using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorizationService.Models;

namespace AuthorizationService.Services.Contracts
{
    public interface IConfirmationRepository
    {
        Task AddConfirmationRequestAsync(ConfirmationRequest confirmationRequest);
        Task<ConfirmationRequest> GetConfirmationRequestByIdAsync(int id);
    }
}
