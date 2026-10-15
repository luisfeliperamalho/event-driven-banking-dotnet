namespace Banking.Contracts.Events;

public sealed record TransferRejected(
    Guid TransferId,
    string SourceAccountId,
    string ReasonCode,
    DateTime OccurredAt);
