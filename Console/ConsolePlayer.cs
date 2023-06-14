using YatzyLib;

public class ConsolePlayer : IPlayer
{
    public string Name { get; set; }
    public List<IScore> Scores { get; set; }
    public int TotalScore { get; set; }
    public IIn Input { get; set; }
    public IOut Output { get; set; }
    public ConsolePlayer(string name)
    {
        this.Input = new Input();
        this.Output = new Output();
        this.Name = name;
        Scores = new List<IScore>();
    }
}