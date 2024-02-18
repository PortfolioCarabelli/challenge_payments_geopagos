using Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AuthorizationService.Services.Contracts
{
    public interface IConfirmationRepository
    {
        Task<ApprovedAuthorization> ConfirmAuthorization(int AutorizationId);
    }
}
