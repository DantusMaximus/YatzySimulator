using YatzyLib;
using YatzySimulator;

public class DataSampler
{
    public List<IPlayer> Players { get; set; }
    public List<string> ScoreOptions { get; set; }
    public int DiceCount { get; set; }
    public int RollCount { get; set; }
    public int Rounds { get; set; }
    public DataSampler(IGame game)
    {
        DiceCount = game.ScoreLogic.Dices.Count;
        RollCount = game.RollCount;
        Rounds = game.Rounds;
        Players = game.Players;
        ScoreOptions = (new SimulatedYatzyInitializer(game.ScoreLogic)).ScoreOptions;
    }
    public DataSample CollectDataSample(SampleType type, int itterationsPerRun, int startVal, int endVal)
    {
        if (type == SampleType.DiceCount) { return CollectDCDataSample(itterationsPerRun, startVal, endVal); }
        if (type == SampleType.RollCount) { return CollectRollCountDataSample(itterationsPerRun, startVal, endVal); }
        if (type == SampleType.Rounds) { return CollectRoundsDataSample(itterationsPerRun, startVal, endVal); }
        throw new NotImplementedException();
    }

    private DataSample CollectRoundsDataSample(int accuracy, int startVal, int endVal)
    {
        var ds = new DataSample(ScoreOptions);
        for (int r = startVal; r <= endVal; r++)
        {
            IGame game = new SimulatedYatzy(Players, DiceCount, 6, RollCount, r, false);
            var init = new SimulatedYatzyInitializer(game.ScoreLogic);
            for (int i = 1; i <= accuracy; i++)
            {
                init.Initialize(game);
                game.RunGame();
                ds.CollectItteration(game);
            }
            ds.AddItterationToResult(accuracy);
        }
        return ds;
    }

    private DataSample CollectRollCountDataSample(int accuracy, int startVal, int endVal)
    {
        var ds = new DataSample(ScoreOptions);
        for (int rc = startVal; rc <= endVal; rc++)
        {
            IGame game = new SimulatedYatzy(Players, DiceCount, 6, rc, Rounds, false);
            var init = new SimulatedYatzyInitializer(game.ScoreLogic);
            for (int i = 1; i <= accuracy; i++)
            {
                init.Initialize(game);
                game.RunGame();
                ds.CollectItteration(game);
            }
            ds.AddItterationToResult(accuracy);
        }
        return ds;
    }

    private DataSample CollectDCDataSample(int accuracy, int startVal, int endVal)
    {
        var ds = new DataSample(ScoreOptions);
        for (int dc = startVal; dc <= endVal; dc++)
        {
            IGame game = new SimulatedYatzy(Players, dc, 6, RollCount, Rounds, false);
            var init = new SimulatedYatzyInitializer(game.ScoreLogic);
            for (int i = 1; i <= accuracy; i++)
            {
                init.Initialize(game);
                game.RunGame();
                ds.CollectItteration(game);
            }
            ds.AddItterationToResult(accuracy);
        }
        return ds;
    }
}
public enum SampleType { DiceCount, RollCount, Rounds }