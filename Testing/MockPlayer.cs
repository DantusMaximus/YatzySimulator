using YatzyLib;
public class MockPlayer : IPlayer
{
    public string Name {get;set;}
    public List<IScore> Scores { get; set; }
    public int TotalScore  { get; set; }
    public IIn Input{get;set;}
    public IOut Output { get ; set ; }
    public void LockDice(int index){return;}
    public MockPlayer(string n, int ts)
    {
        this.TotalScore = ts;
        this.Name = n;
        this.Scores = new List<IScore>();
        this.Input = new MockInput();
    }

}