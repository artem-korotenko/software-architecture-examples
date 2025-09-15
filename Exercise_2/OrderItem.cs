public sealed class OrderItem
{
    public string Sku { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }
    public string Category { get; }

    public OrderItem(string sku, int quantity, Money unitPrice, string category)
    {
        Sku = sku;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Category = category;
    }
}