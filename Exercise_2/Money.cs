public sealed class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Money Add(decimal addition)
    {
        return new Money(Amount + addition, Currency);
    }

    public Money Multiply(decimal factor)
    {
        return new Money(Math.Round(Amount * factor, 2), Currency);
    }
}