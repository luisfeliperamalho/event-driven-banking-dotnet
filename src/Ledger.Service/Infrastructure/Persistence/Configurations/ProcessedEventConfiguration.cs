using Ledger.Service.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ledger.Service.Infrastructure.Persistence.Configurations;

public sealed class ProcessedEventConfiguration : IEntityTypeConfiguration<ProcessedEvent>
{
    public void Configure(EntityTypeBuilder<ProcessedEvent> builder)
    {
        builder.ToTable("processed_events");
        builder.HasKey(processedEvent => processedEvent.TransferId);
        builder.Property(processedEvent => processedEvent.Outcome).HasMaxLength(32).IsRequired();
        builder.Property(processedEvent => processedEvent.ProcessedAt).IsRequired();
    }
}
