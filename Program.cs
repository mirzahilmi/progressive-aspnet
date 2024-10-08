using progressive_aspnet.Contracts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games =
[
    new GameDto(
        1,
        "The Legend of Zelda: Breath of the Wild",
        "Action-Adventure",
        59.99m,
        new DateOnly(2017, 3, 3)
    ),
    new GameDto(2, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17)),
    new GameDto(3, "Stardew Valley", "Simulation", 14.99m, new DateOnly(2016, 2, 26)),
    new GameDto(4, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
    new GameDto(5, "Among Us", "Social Deduction", 4.99m, new DateOnly(2018, 6, 15)),
];

app.MapGet("/games", () => games).WithName(GetGameEndpointName);
app.MapGet(
    "/games/{id}",
    (int id) =>
    {
        var game = games.Find(item => item.ID == id);
        return game is not null ? Results.Ok(game) : Results.NotFound();
    }
);
app.MapPost(
    "/games",
    (CreateGameDto game) =>
    {
        var _game = new GameDto(
            games.Count + 1,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate
        );
        games.Add(_game);
        return Results.CreatedAtRoute(GetGameEndpointName, new { id = _game.ID }, _game);
    }
);
app.MapPut(
    "/games/{id}",
    (int id, UpdateGameDto game) =>
    {
        var i = games.FindIndex(item => item.ID == id);
        games[i] = new GameDto(id, game.Name, game.Genre, game.Price, game.ReleaseDate);
        return Results.NoContent();
    }
);
app.MapDelete(
    "/games/{id}",
    (int id) =>
    {
        games.RemoveAt(games.FindIndex(item => item.ID == id));
        return Results.NoContent();
    }
);

app.Run();
