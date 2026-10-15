using Banking.Contracts.Events;

namespace Fraud.Service.Application;

public interface IFraudEventPublisher
{
    Task PublishApprovedAsync(TransferApproved transferApproved, CancellationToken cancellationToken);
    Task PublishRejectedAsync(TransferRejected transferRejected, CancellationToken cancellationToken);
}
