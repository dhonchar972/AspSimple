using AspCoreMinimalApi.Models;

namespace AspCoreMinimalApi.Data;

public static class SimpleDataStore
{
    private static readonly List<Product> _products = new()
    {
        new()
        {
            Id = 1,
            Name = "Product #1",
            Category = "First",
            Price = 75
        },
        new()
        {
            Id = 2,
            Name = "Product #2",
            Category = "First",
            Price = 112
        },
        new()
        {
            Id = 3,
            Name = "Product #3",
            Category = "Second",
            Price = 1200
        },
        new()
        {
            Id = 4,
            Name = "Product #4",
            Category = "First",
            Price = 145
        }
    };

    public static List<Product> Products => _products;
}