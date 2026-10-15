using Banking.Contracts.Events;

namespace Transfer.Api.Application;

public sealed class CreateTransferHandler(ITransferEventPublisher publisher)
{
    public async Task<CreateTransferResult> HandleAsync(CreateTransferRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.SourceAccountId) || string.IsNullOrWhiteSpace(request.TargetAccountId))
        {
            return CreateTransferResult.ValidationError("Source and target accounts are required.");
        }

        if (string.Equals(request.SourceAccountId, request.TargetAccountId, StringComparison.Ordinal))
        {
            return CreateTransferResult.ValidationError("Source and target accounts must differ.");
        }

        if (request.Amount <= 0)
        {
            return CreateTransferResult.ValidationError("Amount must be greater than zero.");
        }

        var transferId = Guid.NewGuid();
        var transferRequested = new TransferRequested(
            transferId,
            request.SourceAccountId,
            request.TargetAccountId,
            request.Amount,
            DateTime.UtcNow);

        await publisher.PublishRequestedAsync(transferRequested, cancellationToken);

        return CreateTransferResult.Success(transferId);
    }
}
