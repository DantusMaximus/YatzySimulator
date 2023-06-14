using YatzyLib;
public class MockScoreLogic : IScoreLogic
{
    public int DiceCount {get;set;}
    public List<IDice> Dices{get;set;}
    public List<string> ScoreTypes { get ; set ; }

    public MockScoreLogic(List<IDice> dices)
    {
        this.Dices = dices;
    }
    public MockScoreLogic(){;}
}