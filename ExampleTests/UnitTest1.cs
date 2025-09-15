namespace ExampleTests;

using SoftwareArchitectureExamples;

public class Tests
{
    [Test]
    public async Task OrderIsProcessed_WhenPaymentProcessed()
    {
        var processor = new PaymentProcessor(new StubPaymentFactory());
        var result = await processor.ProcessOrder(new Order());
        Assert.That(result, Is.True);
    }
}

public class StubPayment : IPayment
{
    public async Task<bool> ProcessPayment(decimal price)
    {
        return true;
    }
}

public class StubPaymentFactory : IPaymentFactory
{
    public IPayment CreatePayment()
    {
        return new StubPayment();
    }
}
