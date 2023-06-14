namespace YatzyLib;
public interface IGameInitializer
{
    public List<string> ScoreOptions { get; set; }
    public List<Func<int>> SetScoreFunctions { get; set; }
    public void Initialize(IGame game);
}