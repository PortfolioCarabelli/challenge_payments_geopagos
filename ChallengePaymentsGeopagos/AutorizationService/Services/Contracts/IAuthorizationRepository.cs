using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorizationService.Models;

namespace AuthorizationService.Services.Contracts
{
    public interface IAuthorizationRepository
    {
        Task AddAuthorizationRequestAsync(AuthorizationRequest authorizationRequest);
        Task<IEnumerable<AuthorizationRequest>> GetAllAuthorizationRequestsAsync();
    }
}
