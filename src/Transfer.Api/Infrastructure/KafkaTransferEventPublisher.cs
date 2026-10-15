using Banking.Contracts;
using Banking.Contracts.Events;
using Transfer.Api.Application;

namespace Transfer.Api.Infrastructure;

public sealed class KafkaTransferEventPublisher : ITransferEventPublisher
{
    public Task PublishRequestedAsync(TransferRequested transferRequested, CancellationToken cancellationToken)
    {
        // TODO(kafka): produce to Topics.TransferRequested serializing the value as JSON; use SourceAccountId as the message key; add a correlation-id header; producer configured from KafkaOptions.BootstrapServers.
        throw new NotImplementedException();
    }
}
