namespace Fraud.Service.Domain;

public sealed record FraudDecision(bool IsApproved, string? ReasonCode)
{
    public static FraudDecision Approve() => new(true, null);
    public static FraudDecision Reject(string reasonCode) => new(false, reasonCode);
}
