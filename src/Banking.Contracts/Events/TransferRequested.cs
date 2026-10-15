namespace Banking.Contracts.Events;

public sealed record TransferRequested(
    Guid TransferId,
    string SourceAccountId,
    string TargetAccountId,
    decimal Amount,
    DateTime OccurredAt);
