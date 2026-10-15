using Banking.Contracts.Events;
using Fraud.Service.Domain;

namespace Fraud.Service.Application;

public sealed class EvaluateTransferHandler(FraudPolicy policy, IFraudEventPublisher publisher)
{
    public async Task HandleAsync(TransferRequested transferRequested, CancellationToken cancellationToken)
    {
        var decision = policy.Evaluate(transferRequested.Amount);

        if (decision.IsApproved)
        {
            var approved = new TransferApproved(
                transferRequested.TransferId,
                transferRequested.SourceAccountId,
                transferRequested.TargetAccountId,
                transferRequested.Amount,
                DateTime.UtcNow);

            await publisher.PublishApprovedAsync(approved, cancellationToken);
            return;
        }

        var rejected = new TransferRejected(
            transferRequested.TransferId,
            transferRequested.SourceAccountId,
            decision.ReasonCode!,
            DateTime.UtcNow);

        await publisher.PublishRejectedAsync(rejected, cancellationToken);
    }
}
