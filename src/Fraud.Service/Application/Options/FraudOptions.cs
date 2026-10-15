namespace Fraud.Service.Application.Options;

public sealed class FraudOptions
{
    public const string SectionName = "Fraud";
    public decimal MaxAmount { get; set; } = 5000m;
}
