using Ledger.Service.Application;

namespace Ledger.Service.Infrastructure;

public sealed class TransferApprovedConsumer(
    IServiceScopeFactory scopeFactory,
    ILogger<TransferApprovedConsumer> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // TODO(kafka): create a Kafka consumer with group id "ledger-service" (KafkaOptions.GroupId), subscribe to Topics.TransferApproved,
        // then loop: Consume(stoppingToken); deserialize the JSON value to TransferApproved; create a new DI scope (scopeFactory.CreateScope) and
        // resolve ProcessApprovedTransferHandler + LedgerDbContext per message; call HandleAsync; commit the offset manually only after the handler succeeds;
        // catch ConsumeException and log; close/dispose the consumer on shutdown.
        logger.LogWarning("Kafka consumer not implemented yet");

        try
        {
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch (OperationCanceledException)
        {
        }
    }
}
