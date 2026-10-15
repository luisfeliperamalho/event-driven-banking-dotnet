using Ledger.Service.Application;
using Ledger.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Service.Infrastructure.Persistence;

public sealed class ProcessedEventRepository(LedgerDbContext dbContext) : IProcessedEventRepository
{
    public Task<bool> ExistsAsync(Guid transferId, CancellationToken cancellationToken) =>
        dbContext.ProcessedEvents.AnyAsync(processedEvent => processedEvent.TransferId == transferId, cancellationToken);

    public async Task AddAsync(ProcessedEvent processedEvent, CancellationToken cancellationToken) =>
        await dbContext.ProcessedEvents.AddAsync(processedEvent, cancellationToken);
}
