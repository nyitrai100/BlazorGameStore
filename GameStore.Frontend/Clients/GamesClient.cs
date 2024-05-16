using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient
{
 private readonly List<GameSummary> games =
     [
         new(){
             Id = 1,
            Name = "The Witcher 3: Wild Hunt",
            Genre = "RPG",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2015, 5, 19)
             },
            new(){
                Id = 2,
                Name = "Cyberpunk 2077",
                Genre = "RPG",
                Price = 59.99M,
                ReleaseDate = new DateOnly(2020, 12, 10)
            },
            new(){
                Id = 3,
                Name = "Doom Eternal",
                Genre = "FPS",
                Price = 39.99M,
                ReleaseDate = new DateOnly(2020, 3, 20)
            }
    ]; 

    public GameSummary[] GetGames() => [.. games];
}
