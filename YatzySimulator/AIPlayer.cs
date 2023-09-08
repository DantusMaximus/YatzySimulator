using YatzyLib;

public class AIPlayer : IPlayer
{
    public string Name { get; set; }
    public List<IScore> Scores { get; set; }
    public int TotalScore { get; set; }
    public IIn Input { get;set;}
    public IOut ?Output { get; set; }
    public AIScoreMethodType ScoringType { get; set; }
    public delegate void SM(IPlayer p, IScoreLogic sl, List<IDice> d, int rc);
    public SM ?ScoringMethod{get;set;}
    public AIPlayer(string name, AIScoreMethodType scoreType, IOut output)
    {
        Input = new AIInput();
        Name = name;
        this.Scores = new List<IScore>();
        this.TotalScore = 0;
        this.Output = output;
        ScoringType = scoreType;
    }
    public void DoTurn(IScoreLogic sl, List<IDice> dices, int rollCount)
    {
        int timesRolled = 0;
        Roll(dices, ref timesRolled);
        if(ScoringMethod == null){throw new NullReferenceException();}
        ScoringMethod(this, sl, dices, rollCount);
    }
    public void Roll(List<IDice> dices, ref int timesRolled)
    {

        foreach (var d in dices)
        {
            if (!d.Locked == true) d.Roll();
        }
        timesRolled++;
    }
        public void GameOver(IGame game)
    {
        if(Output == null){return;}
        Output.GameOver(game);
    }
    
}
public class AIInput : IIn
{
    public PlayerOption GetInput()
    {
        throw new NotImplementedException();
    }

    public string GetPlayerName()
    {
        throw new NotImplementedException();
    }

    public string GetScoreOption()
    {
        throw new NotImplementedException();
    }

    public void Toggle(List<IDice> dices, IOut o)
    {
        throw new NotImplementedException();
    }

    public bool Valid(PlayerOption option)
    {
        throw new NotImplementedException();
    }
}