namespace Banking.Contracts.Events;

public sealed record TransferFailed(
    Guid TransferId,
    string SourceAccountId,
    string ReasonCode,
    DateTime OccurredAt);
