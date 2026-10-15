namespace Transfer.Api.Application;

public sealed record CreateTransferResponse(Guid TransferId, string Status = "PENDING");
