namespace Banking.Contracts.Events;

public sealed record TransferApproved(
    Guid TransferId,
    string SourceAccountId,
    string TargetAccountId,
    decimal Amount,
    DateTime OccurredAt);
