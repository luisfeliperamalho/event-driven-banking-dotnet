namespace Banking.Contracts;

public static class Topics
{
    public const string TransferRequested = "transfer.requested";
    public const string TransferApproved = "transfer.approved";
    public const string TransferRejected = "transfer.rejected";
    public const string TransferCompleted = "transfer.completed";
    public const string TransferFailed = "transfer.failed";
}
