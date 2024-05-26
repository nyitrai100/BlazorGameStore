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

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummeryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummeryById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;    
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    private GameSummary GetGameSummeryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            return genres.Single(genre => genre.Id == int.Parse(id));
        }
     }


// namespace GameStore.Frontend.Clients
// {
//     public class GamesClient
//     {
//         private readonly List<GameSummary> games = new List<GameSummary>
//         {
//             new()
//             {
//                 Id = 1,
//                 Name = "The Witcher 3: Wild Hunt",
//                 Genre = "Roleplaying",
//                 Price = 29.99M,
//                 ReleaseDate = new DateOnly(2015, 5, 19)
//             },
//             new()
//             {
//                 Id = 2,
//                 Name = "Cyberpunk 2077",
//                 Genre = "Roleplaying",
//                 Price = 59.99M,
//                 ReleaseDate = new DateOnly(2020, 12, 10)
//             },
//             new()
//             {
//                 Id = 3,
//                 Name = "Doom Eternal",
//                 Genre = "FPS",
//                 Price = 39.99M,
//                 ReleaseDate = new DateOnly(2020, 3, 20)
//             }
//         };

//         private readonly Genre[] genres = new GenresClient().GetGenres();

//         public GameSummary[] GetGames() => games.ToArray();

//         public void AddGame(GameDetails game)
//         {
//             ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
//             var genre = genres.Single(g => g.Id == int.Parse(game.GenreId));
//             var gameSummary = new GameSummary
//             {
//                 Id = games.Count + 1,
//                 Name = game.Name,
//                 Genre = genre.Name,
//                 Price = game.Price,
//                 ReleaseDate = game.ReleaseDate
//             };
//             games.Add(gameSummary);
//         }

//         public GameDetails GetGame(int id)
//         {
//             GameSummary? game = games.Find(g => g.Id == id);
//             ArgumentNullException.ThrowIfNull(game);

//             Console.WriteLine($"Looking for genre: '{game.Genre}'");
//             foreach (var g in genres)
//             {
//                 Console.WriteLine($"Available genre: '{g.Name}'");
//             }

//             var genre = genres.SingleOrDefault(g => string.Equals(g.Name.Trim(), game.Genre.Trim(), StringComparison.OrdinalIgnoreCase));

//             if (genre == null)
//             {
//                 throw new InvalidOperationException($"Genre '{game.Genre}' not found.");
//             }

//             return new GameDetails
//             {
//                 Id = game.Id,
//                 Name = game.Name,
//                 GenreId = genre.Id.ToString(),
//                 Price = game.Price,
//                 ReleaseDate = game.ReleaseDate
//             };
//         }
//     }
// }


