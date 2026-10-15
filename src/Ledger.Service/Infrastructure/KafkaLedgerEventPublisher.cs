using Banking.Contracts;
using Banking.Contracts.Events;
using Ledger.Service.Application;

namespace Ledger.Service.Infrastructure;

public sealed class KafkaLedgerEventPublisher : ILedgerEventPublisher
{
    public Task PublishCompletedAsync(TransferCompleted transferCompleted, CancellationToken cancellationToken)
    {
        // TODO(kafka): produce to Topics.TransferCompleted serializing the value as JSON; use SourceAccountId as the message key; add a correlation-id header; producer configured from KafkaOptions.BootstrapServers.
        throw new NotImplementedException();
    }

    public Task PublishFailedAsync(TransferFailed transferFailed, CancellationToken cancellationToken)
    {
        // TODO(kafka): produce to Topics.TransferFailed serializing the value as JSON; use SourceAccountId as the message key; add a correlation-id header; producer configured from KafkaOptions.BootstrapServers.
        throw new NotImplementedException();
    }
}
