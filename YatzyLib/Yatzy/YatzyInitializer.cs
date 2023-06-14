namespace YatzyLib;
public class YatzyInitializer : IGameInitializer
{
    public List<string> ScoreOptions { get; set; }
    public List<Func<int>> SetScoreFunctions { get; set; }
    public YatzyInitializer(IScoreLogic sl)
    {
        this.ScoreOptions = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six", "Pair", "ToK", "FoK", "House", "SS", "LS", "C", "Y" };
        this.SetScoreFunctions = new List<Func<int>>(){sl.One,sl.Two,sl.Three,sl.Four,sl.Five,sl.Six
        ,sl.Pair,sl.ThreeOfAKind,sl.FourOfAKind,sl.House,sl.SmallStraight,sl.LargeStraight
        ,sl.Chance,sl.Yatzy};
    }
    private void InitializeScores(List<IPlayer> players)
    {
        foreach (var p in players)
        {
            p.Scores.Clear();
            for (int i = 0; i < ScoreOptions.Count; i++)
            {
                p.Scores.Add(new YatzyScore(ScoreOptions[i], SetScoreFunctions[i]));
            }
        }

    }

    public void Initialize(IGame game)
    {
        InitializeScores(game.Players);
    }
}