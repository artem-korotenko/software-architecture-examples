public sealed class Order
{
    public Customer Customer { get; }
    public IReadOnlyList<OrderItem> Items { get; }
    public string Coupon { get; }             // e.g., "WELCOME10", "FREESHIP"
    public decimal ShippingCost { get; }      // pre-computed base

    public Order(Customer customer, IReadOnlyList<OrderItem> items, string coupon, decimal shippingCost)
    {
        Customer = customer;
        Items = items;
        Coupon = coupon;
        ShippingCost = shippingCost;
    }
}