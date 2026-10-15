namespace Transfer.Api.Infrastructure;

public sealed class KafkaOptions
{
    public const string SectionName = "Kafka";
    public string BootstrapServers { get; set; } = string.Empty;
}
