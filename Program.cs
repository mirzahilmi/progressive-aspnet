using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using progressive_aspnet.DB;
using progressive_aspnet.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "PizzaStore API",
            Description = "Making the Pizzas you love",
            Version = "v1"
        }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.MapGet("/", () => "Hello World!");

var pizzas = app.MapGroup("/pizzas");
pizzas.MapGet("/", async (PizzaDb db) => Results.Ok(await db.Pizzas.ToListAsync()));
pizzas.MapGet("/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
pizzas.MapPost(
    "/",
    async (PizzaDb db, Pizza pizza) =>
    {
        await db.Pizzas.AddAsync(pizza);
        await db.SaveChangesAsync();
        return Results.Created($"/pizzas/{pizza.Id}", pizza);
    }
);
pizzas.MapPut(
    "/{id}",
    async (PizzaDb db, Pizza pizza, int id) =>
    {
        var _pizza = await db.Pizzas.FindAsync(id);
        if (_pizza is null)
            return Results.NotFound();
        _pizza = pizza;
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
);
pizzas.MapDelete(
    "/{id}",
    async (PizzaDb db, int id) =>
    {
        var pizza = await db.Pizzas.FindAsync(id);
        if (pizza is null)
            return Results.NotFound();
        db.Pizzas.Remove(pizza);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
);

app.Run();
