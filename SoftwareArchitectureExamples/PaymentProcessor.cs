namespace SoftwareArchitectureExamples;

public class PaymentProcessor(IPaymentFactory paymentFactory)
{

    public async Task<bool> ProcessOrder(Order order)
    {
        var price = order.CalculateTotalPrice();
        var payment = paymentFactory.CreatePayment();
        var paymentSuccessful = await payment.ProcessPayment(price);
        return paymentSuccessful;
    }
}

public interface IPaymentFactory
{
    IPayment CreatePayment();
}

public class Order
{
    public decimal CalculateTotalPrice() => 0;
}

public interface IPayment
{
    Task<bool> ProcessPayment(decimal price);
}

public class CreditCardPayment : IPayment
{
    public async Task<bool> ProcessPayment(decimal price) { return true; }
}

public class PayPalPayment : IPayment
{
    public async Task<bool> ProcessPayment(decimal price)
    {
        return true;
    }
}

