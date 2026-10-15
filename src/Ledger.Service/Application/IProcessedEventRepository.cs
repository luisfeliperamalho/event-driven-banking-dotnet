using Ledger.Service.Domain;

namespace Ledger.Service.Application;

public interface IProcessedEventRepository
{
    Task<bool> ExistsAsync(Guid transferId, CancellationToken cancellationToken);
    Task AddAsync(ProcessedEvent processedEvent, CancellationToken cancellationToken);
}
