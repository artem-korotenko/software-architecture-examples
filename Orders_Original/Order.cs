namespace Orders_Original;

public class Order
{
    private readonly List<ShoppingItem> items;

    public Order(List<ShoppingItem> items)
    {
        this.items = items;
    }

    private decimal TotalAmount => items.Sum(item => item.Price);
    public string CustomerType { get; set; }

    public decimal GetDiscountedTotal(int totalPurchases)
    {
        var extraCoefficient = totalPurchases > 0 ? 0 : -0.25m;
        if (CustomerType == "Regular")
        {
            return TotalAmount * ( 1m + extraCoefficient);
        }
        if (CustomerType == "Premium")
        {
            return TotalAmount * (0.9m + extraCoefficient); 
        }
        if (CustomerType == "VIP")
        {
            return TotalAmount * (0.8m + extraCoefficient); 
        }
        return TotalAmount;
    }
}