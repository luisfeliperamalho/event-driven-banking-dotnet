using Banking.Contracts.Events;

namespace Ledger.Service.Application;

public interface ILedgerEventPublisher
{
    Task PublishCompletedAsync(TransferCompleted transferCompleted, CancellationToken cancellationToken);
    Task PublishFailedAsync(TransferFailed transferFailed, CancellationToken cancellationToken);
}
