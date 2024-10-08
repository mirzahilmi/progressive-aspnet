namespace progressive_aspnet.Contracts;

public record class GameDto(int ID, string Name, string Genre, decimal Price, DateOnly ReleaseDate);
