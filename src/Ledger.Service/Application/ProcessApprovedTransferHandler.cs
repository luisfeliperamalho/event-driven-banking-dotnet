using Banking.Contracts.Events;
using Ledger.Service.Domain;

namespace Ledger.Service.Application;

public sealed class ProcessApprovedTransferHandler(
    IAccountRepository accountRepository,
    IProcessedEventRepository processedEventRepository,
    IUnitOfWork unitOfWork,
    ILedgerEventPublisher publisher)
{
    public async Task HandleAsync(TransferApproved transferApproved, CancellationToken cancellationToken)
    {
        if (await processedEventRepository.ExistsAsync(transferApproved.TransferId, cancellationToken))
        {
            return;
        }

        var source = await accountRepository.GetByIdAsync(transferApproved.SourceAccountId, cancellationToken);
        var target = await accountRepository.GetByIdAsync(transferApproved.TargetAccountId, cancellationToken);

        if (source is null || target is null)
        {
            await RecordAndPublishFailureAsync("ACCOUNT_NOT_FOUND", transferApproved, cancellationToken);
            return;
        }

        try
        {
            source.Debit(transferApproved.Amount);
            target.Credit(transferApproved.Amount);
        }
        catch (InsufficientFundsException)
        {
            await RecordAndPublishFailureAsync("INSUFFICIENT_FUNDS", transferApproved, cancellationToken);
            return;
        }

        await processedEventRepository.AddAsync(
            new ProcessedEvent(transferApproved.TransferId, DateTime.UtcNow, ProcessedEventOutcome.Completed),
            cancellationToken);

        await unitOfWork.BeginTransactionAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await unitOfWork.CommitTransactionAsync(cancellationToken);

        // Publishing happens after the commit, so a crash between commit and publish can lose the event.
        // This is the gap the Outbox Pattern closes; it is intentionally out of scope here.
        var completed = new TransferCompleted(
            transferApproved.TransferId,
            transferApproved.SourceAccountId,
            transferApproved.TargetAccountId,
            transferApproved.Amount,
            DateTime.UtcNow);

        await publisher.PublishCompletedAsync(completed, cancellationToken);
    }

    private async Task RecordAndPublishFailureAsync(
        string reasonCode,
        TransferApproved transferApproved,
        CancellationToken cancellationToken)
    {
        await processedEventRepository.AddAsync(
            new ProcessedEvent(transferApproved.TransferId, DateTime.UtcNow, ProcessedEventOutcome.Failed),
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var failed = new TransferFailed(
            transferApproved.TransferId,
            transferApproved.SourceAccountId,
            reasonCode,
            DateTime.UtcNow);

        await publisher.PublishFailedAsync(failed, cancellationToken);
    }
}
