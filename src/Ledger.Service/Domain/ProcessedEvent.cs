namespace Ledger.Service.Domain;

public sealed class ProcessedEvent
{
    public Guid TransferId { get; private set; }
    public DateTime ProcessedAt { get; private set; }
    public string Outcome { get; private set; }

    private ProcessedEvent()
    {
        Outcome = null!;
    }

    public ProcessedEvent(Guid transferId, DateTime processedAt, string outcome)
    {
        TransferId = transferId;
        ProcessedAt = processedAt;
        Outcome = outcome;
    }
}
