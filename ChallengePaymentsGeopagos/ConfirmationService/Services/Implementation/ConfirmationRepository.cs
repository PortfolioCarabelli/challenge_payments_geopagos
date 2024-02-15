using AuthorizationService.Data;
using AuthorizationService.Models;
using AuthorizationService.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Services.Implementation
{
    public class ConfirmationRepository : IConfirmationRepository
    {

        private readonly ApplicationDbContext _context;

        public ConfirmationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddConfirmationRequestAsync(ConfirmationRequest confirmationRequest)
        {
            _context.ConfirmationRequest.Add(confirmationRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<ConfirmationRequest> GetConfirmationRequestByIdAsync(int id)
        {
            return await _context.ConfirmationRequest.FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
