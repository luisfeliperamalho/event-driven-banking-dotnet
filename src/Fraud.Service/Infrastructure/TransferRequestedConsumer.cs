using Fraud.Service.Application;

namespace Fraud.Service.Infrastructure;

public sealed class TransferRequestedConsumer(
    IServiceScopeFactory scopeFactory,
    ILogger<TransferRequestedConsumer> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // TODO(kafka): create a Kafka consumer with group id "fraud-service" (KafkaOptions.GroupId), subscribe to Topics.TransferRequested,
        // then loop: Consume(stoppingToken); deserialize the JSON value to TransferRequested; resolve EvaluateTransferHandler from a new DI scope
        // (scopeFactory.CreateScope) and call HandleAsync; commit the offset manually only after the handler succeeds; catch ConsumeException and log;
        // close/dispose the consumer on shutdown.
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
