using YatzyLib;
public class MockGame : IGame
{
    public string GameType { get; set; }
    public List<IPlayer> Players {get;set;}
    public IScoreLogic ScoreLogic{get;set;}
    public List<IDice> Dices {get;set;}
    public IOut Output {get;set;}
    public int RollCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int ScoreCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Rounds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void RunGame(){throw new System.NotImplementedException();}
    public MockGame(List<IPlayer> players)
    {
        this.Players = players;
        for(int i=1;i<=5;i++)
        {
            this.Dices.Add(new MockDice(6, 1));
        }
    }
    public static List<MockDice> MakeMockDice(int[] value)
    {
        var md = new List<MockDice>();
        foreach(var v in value)
        {
            md.Add(new MockDice(6,v));
        }
        return md;
    }
}