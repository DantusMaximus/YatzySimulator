using FileManager;
using YatzyLib;
using System.Text.Json;
public class SimulatedYatzyReader : IGameReader
{
    public string Path { get; set; }
    public SimulatedYatzyReader(string path)
    {
        Path = path;
    }

    public IGame Read()
    {
        using (StreamReader sr = new StreamReader(Path))
        {
            var json = sr.ReadToEnd();
            IGame? game = JsonSerializer.Deserialize<IGame>(json);
            if (game == null) { throw new System.NullReferenceException(); }
            IGameInitializer ?gameInitializer = null;
            if (game.GameType == "Yatzy") { gameInitializer = new YatzyInitializer(game.ScoreLogic);}
            if(game.GameType=="SimulatedYatzy"){gameInitializer = new SimulatedYatzyInitializer(game.ScoreLogic);}
            if(gameInitializer == null){throw new NotImplementedException();}
            gameInitializer.Initialize(game);
            return game;
        }
    }

    public IGame ReadPlayers()
    {
        throw new NotImplementedException();
    }
}