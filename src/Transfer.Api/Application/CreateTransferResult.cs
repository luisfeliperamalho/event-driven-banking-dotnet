namespace Transfer.Api.Application;

public sealed record CreateTransferResult
{
    public bool IsSuccess { get; init; }
    public Guid? TransferId { get; init; }
    public string? Error { get; init; }

    public static CreateTransferResult Success(Guid transferId) => new() { IsSuccess = true, TransferId = transferId };

    public static CreateTransferResult ValidationError(string error) => new() { IsSuccess = false, Error = error };
}
