using Banking.Contracts;
using Banking.Contracts.Events;
using Fraud.Service.Application;

namespace Fraud.Service.Infrastructure;

public sealed class KafkaFraudEventPublisher : IFraudEventPublisher
{
    public Task PublishApprovedAsync(TransferApproved transferApproved, CancellationToken cancellationToken)
    {
        // TODO(kafka): produce to Topics.TransferApproved serializing the value as JSON; use SourceAccountId as the message key; add a correlation-id header; producer configured from KafkaOptions.BootstrapServers.
        throw new NotImplementedException();
    }

    public Task PublishRejectedAsync(TransferRejected transferRejected, CancellationToken cancellationToken)
    {
        // TODO(kafka): produce to Topics.TransferRejected serializing the value as JSON; use SourceAccountId as the message key; add a correlation-id header; producer configured from KafkaOptions.BootstrapServers.
        throw new NotImplementedException();
    }
}
