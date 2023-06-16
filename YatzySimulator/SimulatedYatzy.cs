namespace YatzySimulator;
using System.Collections.Generic;
using YatzyLib;
public class SimulatedYatzy : IGame
{
    public string GameType { get; set; }
    public List<IPlayer> Players { get ; set ; }
    public IScoreLogic ScoreLogic { get ; set ; }
    public int DiceCount { get; set; }
    public int RollCount { get ; set ; }
    public int Rounds { get ; set ; }
    public bool UseScores{get;set;}

    public SimulatedYatzy(List<IPlayer> players, int diceCount, int diceMax, int rollCount, int rounds, bool useScores)
    {
        GameType = "SimulatedYatzy";
        Players = players;
        var dices = new List<IDice>();
        for(int i = 1; i<=diceCount;i++){ dices.Add(new Dice(false,1,diceMax));}
        ScoreLogic = new YatzyScoreLogic(dices);
        DiceCount = diceCount;
        RollCount = rollCount;
        Rounds = rounds;
        UseScores = useScores;
        var init = new SimulatedYatzyInitializer(ScoreLogic);
        init.Initialize(this);
    }
}
