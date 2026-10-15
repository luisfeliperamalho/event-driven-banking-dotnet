namespace Transfer.Api.Application;

public sealed record CreateTransferRequest(string SourceAccountId, string TargetAccountId, decimal Amount);
