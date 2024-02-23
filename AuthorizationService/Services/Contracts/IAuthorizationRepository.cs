using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.DTOs;
using Persistence.Models;


namespace AuthorizationService.Services.Contracts
{
    public interface IAuthorizationRepository
    {
        Task<AuthorizationRequest> AuthorizePayment(AuthorizationRequest requestDTO);
        Task<List<AuthorizationRequest>> GetPendingAuthorizationsAsync(); 
        Task ReverseAuthorizationAsync(AuthorizationRequest authorizationRequest); 
    }
}
