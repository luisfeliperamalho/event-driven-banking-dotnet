namespace Ledger.Service.Domain;

public sealed class InsufficientFundsException(string accountId)
    : Exception($"Account '{accountId}' has insufficient funds for this debit.")
{
    public string AccountId { get; } = accountId;
}
