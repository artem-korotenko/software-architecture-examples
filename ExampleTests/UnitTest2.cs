namespace ExampleTests;

using NSubstitute;
using SoftwareArchitectureExamples;

public class SubstituteTests
{
    [Test]
    public async Task OrderIsProcessed_WhenPaymentProcessed()
    {
        var stubfactory = Substitute.For<IPaymentFactory>();
        var stubPayment = Substitute.For<IPayment>();
        stubPayment.ProcessPayment(0).ReturnsForAnyArgs(true);
        stubfactory.CreatePayment().Returns(stubPayment);
        
        var processor = new PaymentProcessor(stubfactory);
        var result = await processor.ProcessOrder(new Order());
        Assert.That(result, Is.True);
    }
}
