using Persistence.Models;

namespace ReportingService.Services.Contracts
{
    public interface IReportingRepository
    {
        Task<IEnumerable<Report>> GetApprovedAuthorizationsAsync();
    }
}
