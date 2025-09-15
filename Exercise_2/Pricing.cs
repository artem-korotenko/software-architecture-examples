public static class Pricing
{
    public static Money CalculateTotal(Order order)
    {
        var subtotal = new Money(order.Items.Sum(i => i.UnitPrice.Amount * i.Quantity), "UAH");
        var total = subtotal.Amount;

        if (order.Customer.Country == "DE")
        {
            total = total * 1.19m;
        }
        else if (order.Customer.Country == "PL")
        {
            total = total * 1.23m;
        }
        else if (order.Customer.Country == "UA")
        {
            total = total * 1.20m; // VAT
        }

        if (order.Customer.Tier == "gold")
        {
            total = total * 0.95m;
        }
        else if (order.Customer.Tier == "vip")
        {
            total = total * 0.90m;
        }

        // Student promo
        if (order.Customer.IsStudent)
        {
            int eduQty = order.Items.Where(i => i.Category == "EDU").Sum(i => i.Quantity);
            total = total - (50m * eduQty);
        }

        if (!string.IsNullOrWhiteSpace(order.Coupon))
        {
            if (order.Coupon == "WELCOME10")
            {
                total = total * 0.90m;
            }
            else if (order.Coupon == "FREESHIP")
            {
                // waive shipping
            }
            else if (order.Coupon == "BULK5" && order.Items.Sum(i => i.Quantity) >= 5)
            {
                total = total * 0.95m;
            }
        }

        if (order.Coupon != "FREESHIP")
        {
            total = total + order.ShippingCost;
        }

        if (order.Items.Any(i => i.Category == "HAZMAT"))
        {
            total = total * 1.05m;
        }

        return new Money(Math.Round(total, 2), subtotal.Currency);
    }
}