namespace Orders_Original;

public class Order
{
    public double TotalAmount { get; set; }
    public string CustomerType { get; set; }

    private IDiscountStrategy discountStrategy;

    public Order(IDiscountStrategy discountStrategy)
    {
        this.discountStrategy = discountStrategy;
    }

    public double GetDiscountedTotal()
    {
        return TotalAmount * discountStrategy.GetDiscountAmount();
    }
}

