using YatzyLib;
using System.Text.Json;
using System.Text.Json.Nodes;
using YatzySimulator;

public class SimulatedYatzyWriter : IGameWriter
{
    public string Path { get; set; }
    public SimulatedYatzyWriter(string path)
    {
        Path = path;
    }

    public void Write(IGame game)
    {
        foreach (var p in game.Players)
        {
            foreach (var s in p.Scores)
            {
                s.SetScore = null;
            }
        }
        using (StreamWriter sr = new StreamWriter(Path))
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = "";
            if (game.GetType() == typeof(Yatzy)) { json = JsonSerializer.Serialize((Yatzy)game); }
            if (game.GetType() == typeof(SimulatedYatzy)) { json = JsonSerializer.Serialize((SimulatedYatzy)game); }
            sr.WriteLineAsync(json);
        }
    }
    public void Sample(string folder, DataSample dataSample)
    {
        var time = DateTime.Now.ToString("yyyy-dd-MM");
        using (StreamWriter sr = new StreamWriter(folder + @"\" + time + "Tests" + ".txt", true))
        {
            if (dataSample.SampleType == SampleType.DiceCount) { DCSample(sr, dataSample); }
            if (dataSample.SampleType == SampleType.RollCount) { RCSample(sr, dataSample); }
            if (dataSample.SampleType == SampleType.Rounds) { RSample(sr, dataSample); }
        }
    }
    public void DCSample(StreamWriter sr, DataSample dataSample)
    {
        string append = "";
        int dc = dataSample.StartVal;
        int i = 0;
        foreach (var sd in dataSample.ScoreData)
        {
            append += dataSample.StartVal + i + ",";
            append += dataSample.RollCount + ",";
            append += dataSample.Rounds + "," + ":";
            for (int j = 0; i < dataSample.ScoreData.Count; j++)
            {
                append += $"{dataSample.ScoreOptionsData[j]},{sd[j]}:";
            }
            append += System.Environment.NewLine;
            i++;
        }
        append.Trim(':');
        sr.WriteLineAsync(append);
    }
    public void RCSample(StreamWriter sr, DataSample dataSample)
    {

    }
    public void RSample(StreamWriter sr, DataSample dataSample)
    {

    }

}