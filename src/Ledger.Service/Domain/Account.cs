namespace Ledger.Service.Domain;

public sealed class Account
{
    public string Id { get; private set; }
    public decimal Balance { get; private set; }

    private Account()
    {
        Id = null!;
    }

    public Account(string id, decimal balance)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Account id is required.", nameof(id));
        }

        if (balance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(balance), "Initial balance cannot be negative.");
        }

        Id = id;
        Balance = balance;
    }

    public void Debit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Debit amount must be greater than zero.");
        }

        if (Balance - amount < 0)
        {
            throw new InsufficientFundsException(Id);
        }

        Balance -= amount;
    }

    public void Credit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Credit amount must be greater than zero.");
        }

        Balance += amount;
    }
}
