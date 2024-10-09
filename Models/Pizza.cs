namespace progressive_aspnet.Models;

using Microsoft.EntityFrameworkCore;

public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

class PizzaDb(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}
