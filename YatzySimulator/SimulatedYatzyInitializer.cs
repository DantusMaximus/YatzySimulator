using YatzyLib;
using YatzySimulator;

public class SimulatedYatzyInitializer : IGameInitializer
{
    public List<IScore>? Scores { get; set; }
    public List<string> ScoreOptions { get; set; }
    public List<Func<int>> SetScoreFunctions { get; set; }
    public IScoreLogic? ScoreLogic { get; set; }
    public SimulatedYatzyInitializer(IScoreLogic sl)
    {
        this.ScoreOptions = new List<string>() { "SS", "Y" };
        this.SetScoreFunctions = new List<Func<int>>() { sl.SmallStraight, sl.Yatzy };
    }
    private void InitializeScoreMethods(List<IPlayer> player)
    {
        var aiSM = new AIScoreMethods();
        foreach (var p in player)
        {
            InitializeScoreMethod((AIPlayer)p, aiSM);
        }

    }
    private void InitializeScoreMethod(AIPlayer p, AIScoreMethods aiSM)
    {
        if (p.ScoringType == AIScoreMethodType.Yatzy) { p.ScoringMethod = aiSM.YatzyScoreMethod; return; }
        if (p.ScoringType == AIScoreMethodType.SmallStraight) { p.ScoringMethod = aiSM.SmallStraightScoreMethod; return; }
        throw new NotImplementedException();
    }


    public void Initialize(IGame game)
    {
        InitializeScores(game.Players, useScores((SimulatedYatzy)game));
        InitializeScoreMethods(game.Players);
    }
    private bool useScores(SimulatedYatzy g)
    {
        return g.UseScores;
    }
    public void InitializeScores(List<IPlayer> players, bool useScores)
    {
        foreach (var p in players)
        {
            p.Scores.Clear();
            for (int i = 0; i < ScoreOptions.Count; i++)
            {
                p.Scores.Add(new SimulatedScore(ScoreOptions[i], SetScoreFunctions[i], useScores));
            }
        }

    }
}