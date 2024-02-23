using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Models;
using ReportingService.Services.Contracts;

namespace ReportingService.Services.Implementation
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly AplicationDbContext _context;

        public ReportingRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetApprovedAuthorizationsAsync()
        {
            return await _context.ApprovedAuthorizations
                .Select(authorization => new Report
                {
                    Date = (DateTime)authorization.ApprovalDate,
                    Amount = authorization.Amount,
                    ClientId = authorization.ClientId
                })
                .ToListAsync();
        }

    }
}
