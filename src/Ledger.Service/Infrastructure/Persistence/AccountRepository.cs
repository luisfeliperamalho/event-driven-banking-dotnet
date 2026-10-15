using Ledger.Service.Application;
using Ledger.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Service.Infrastructure.Persistence;

public sealed class AccountRepository(LedgerDbContext dbContext) : IAccountRepository
{
    public Task<Account?> GetByIdAsync(string id, CancellationToken cancellationToken) =>
        dbContext.Accounts.FirstOrDefaultAsync(account => account.Id == id, cancellationToken);
}
