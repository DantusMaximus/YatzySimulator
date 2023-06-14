namespace YatzyLib;
using YatzyLib;
public class Yatzy : IGame
{
    public string GameType { get; set; }
    public List<IPlayer> Players { get; set; }
    public IScoreLogic ScoreLogic { get; set; }
    public int RollCount { get; set; }
    public int ScoreCount { get; set; }
    public int Rounds { get ; set ; }

    public Yatzy(List<IPlayer> players)
    {
        GameType = "Yatzy";
        Players = players;
        ScoreLogic = new YatzyScoreLogic(YatzyDices());
        RollCount = 3;
        Rounds = 14;
        var init = new YatzyInitializer(this.ScoreLogic);
        init.Initialize(this);
    }
    static public List<IDice> YatzyDices()
    {
        List<IDice> yd = new List<IDice>();
        for(int i = 1;i<=5;i++)
        {
            yd.Add(new D6());
        }
        return yd;
    }

}