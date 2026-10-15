using Ledger.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Service.Infrastructure.Persistence;

public sealed class DbSeeder(LedgerDbContext dbContext)
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.Database.MigrateAsync(cancellationToken);

        if (await dbContext.Accounts.AnyAsync(cancellationToken))
        {
            return;
        }

        dbContext.Accounts.AddRange(
            new Account("A1", 10000m),
            new Account("B2", 500m),
            new Account("C3", 0m));

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
