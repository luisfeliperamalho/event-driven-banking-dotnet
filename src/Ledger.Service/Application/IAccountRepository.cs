using Ledger.Service.Domain;

namespace Ledger.Service.Application;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
