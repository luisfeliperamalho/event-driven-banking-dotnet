namespace Banking.Contracts.Events;

public sealed record TransferCompleted(
    Guid TransferId,
    string SourceAccountId,
    string TargetAccountId,
    decimal Amount,
    DateTime OccurredAt);
