using Banking.Contracts.Events;

namespace Transfer.Api.Application;

public interface ITransferEventPublisher
{
    Task PublishRequestedAsync(TransferRequested transferRequested, CancellationToken cancellationToken);
}
