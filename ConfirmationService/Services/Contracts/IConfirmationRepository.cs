using Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ConfirmationService.Services.Contracts
{
    public interface IConfirmationRepository
    {
        Task<ApprovedAuthorization> ConfirmAuthorization(int AutorizationId);
    }
}
