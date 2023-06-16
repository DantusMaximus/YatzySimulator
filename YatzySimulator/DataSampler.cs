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
    public DataSample CollectDataSample(SampleType type, int accuracy, int domainCount)
    {
        switch(type){
            case SampleType.DiceCount: return CollectDCDataSample(accuracy, domainCount);
            case SampleType.RollCount: return CollectRollCountDataSample(accuracy, domainCount);
            case SampleType.Rounds: return CollectRoundsDataSample(accuracy, domainCount);
            default: throw new NotImplementedException();

        }
    }


    private DataSample CollectDCDataSample(int accuracy, int domainCount)
    {
        var ds = new DataSample(SampleType.DiceCount, ScoreOptions, domainCount,accuracy,DiceCount,RollCount,Rounds);
        for (int domainIncrement = 0; domainIncrement < domainCount; domainIncrement++)
        {
            IGame game = new SimulatedYatzy(Players, DiceCount+domainIncrement, 6, RollCount, Rounds, false);
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
    private DataSample CollectRollCountDataSample(int accuracy, int domainCount)
    {
        var ds = new DataSample(SampleType.RollCount, ScoreOptions, domainCount,accuracy,DiceCount,RollCount,Rounds);
        for (int domainIncrement = 0; domainIncrement < domainCount; domainIncrement++)
        {
            IGame game = new SimulatedYatzy(Players, DiceCount, 6, RollCount+domainIncrement, Rounds, false);
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

    private DataSample CollectRoundsDataSample(int accuracy, int domainCount)
    {
        var ds = new DataSample(SampleType.Rounds, ScoreOptions, domainCount,accuracy,DiceCount,RollCount,Rounds);
        for (int domainIncrement = 0; domainIncrement < domainCount; domainIncrement++)
        {
            IGame game = new SimulatedYatzy(Players, DiceCount, 6, RollCount, Rounds+domainIncrement, false);
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