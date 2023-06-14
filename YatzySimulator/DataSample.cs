using YatzyLib;

public class DataSample
{
    public List<List<double>> ScoreData { get; set; }
    public List<double> Iteration { get; set; }
    public List<string> ScoreOptionsData { get; set; }
    public int DiceCount { get; set; }
    public int RollCount { get; set; }
    public int Rounds { get; set; }

    public List<AIScoreMethodType> ScoringTypeData { get; set; }
    public SampleType SampleType { get; set; }
    public int Accuracy { get; set; }
    public int StartVal { get; set; }
    public int EndVal { get; set; }
    public DataSample(List<string> scoreOptions)
    {
        ScoreOptionsData = scoreOptions;
        Iteration = new List<double>();
        ScoreData = new List<List<double>>();
    }
    public void CollectItteration(IGame game)
    {
        if (Iteration.Count == 0)
        {

            foreach (var p in game.Players)
            {
                for (int i = 0; i < p.Scores.Count; i++)
                {

                    Iteration.Add(p.Scores[i].Value);
                }
            }
            return;
        }
        foreach (var p in game.Players)
        {
            for (int i = 0; i < p.Scores.Count; i++)
            {
                Iteration[i] += p.Scores[i].Value;
                i++;
            }
        }
    }
    public void AddItterationToResult(int accuracy)
    {
        for (int i = 0; i < Iteration.Count; i++)
        {
            Iteration[i] /= accuracy;
        }
        var result = new List<double>();
        foreach (var v in Iteration) { result.Add(v); }
        ScoreData.Add(result);
        Iteration.Clear();
    }
}