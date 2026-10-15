namespace Fraud.Service.Domain;

public sealed class FraudPolicy(decimal maxAmount)
{
    public FraudDecision Evaluate(decimal amount) =>
        amount > maxAmount
            ? FraudDecision.Reject("AMOUNT_ABOVE_LIMIT")
            : FraudDecision.Approve();
}
