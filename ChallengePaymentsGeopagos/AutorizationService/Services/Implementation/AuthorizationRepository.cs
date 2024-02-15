using AuthorizationService.Data;
using AuthorizationService.Models;
using AuthorizationService.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Services.Implementation
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorizationRequestAsync(AuthorizationRequest authorizationRequest)
        {
            _context.AuthorizationRequests.Add(authorizationRequest);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<AuthorizationRequest>> GetAllAuthorizationRequestsAsync()
        {
            return await _context.AuthorizationRequests.ToListAsync();
        }
    }
}
