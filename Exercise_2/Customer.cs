public sealed class Customer
{
    public string Id { get; }
    public string Tier { get; } // "regular", "gold", "vip"
    public string Country { get; } // UA
    public bool IsStudent { get; }

    public Customer(string id, string tier, string country, bool isStudent)
    {
        Id = id;
        Tier = tier;
        Country = country;
        IsStudent = isStudent;
    }
}