namespace progressive_aspnet.Contracts;

public record class UpdateGameDto(string Name, string Genre, decimal Price, DateOnly ReleaseDate);
