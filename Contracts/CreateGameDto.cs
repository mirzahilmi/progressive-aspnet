namespace progressive_aspnet.Contracts;

public record class CreateGameDto(string Name, string Genre, decimal Price, DateOnly ReleaseDate);
