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
        using (StreamWriter sr = new StreamWriter(folder + @"\" + time + "Tests" + ".txt"))
        {
            switch (dataSample.SampleType)
            {
                case SampleType.DiceCount:
                    DCSample(sr, dataSample);
                    break;
                case SampleType.RollCount:
                    RCSample(sr, dataSample);
                    break;
                case SampleType.Rounds:
                    RSample(sr, dataSample);
                    break;
            }
        }
    }
    public void DCSample(StreamWriter sr, DataSample dataSample)
    {
        string append = "";
        int i = 0;
        foreach (var sd in dataSample.ScoreData)
        {
            var row = "";
            row += dataSample.DiceCount + i++ + ".";
            row += dataSample.RollCount + ".";
            row += dataSample.Rounds + "|";
            for (int j = 0; j < dataSample.ScoreOptionsData.Count; j++)
            {
                var result = String.Format("{0:G4}", sd[j]);
                row += $"{dataSample.ScoreOptionsData[j]}:{result};";
            }
            append += row + Environment.NewLine;
        }
        append.Trim(':');
        sr.WriteLineAsync(append);
    }
    public void RCSample(StreamWriter sr, DataSample dataSample)
    {
        string append = "";
        int i = 0;
        foreach (var sd in dataSample.ScoreData)
        {
            var row = "";
            row += dataSample.DiceCount + ".";
            row += dataSample.RollCount + i++ + ".";
            row += dataSample.Rounds + "|";
            for (int j = 0; j < dataSample.ScoreOptionsData.Count; j++)
            {
                var result = String.Format("{0:G4}", sd[j]);
                row += $"{dataSample.ScoreOptionsData[j]}:{result};";
            }
            append += row + Environment.NewLine;
        }
        append.Trim(':');
        sr.WriteLineAsync(append);

    }
    public void RSample(StreamWriter sr, DataSample dataSample)
    {
        string append = "";
        int i = 0;
        foreach (var sd in dataSample.ScoreData)
        {
            var row = "";
            row += dataSample.DiceCount + ".";
            row += dataSample.RollCount + ".";
            row += dataSample.Rounds + i++ + "|";
            for (int j = 0; j < dataSample.ScoreOptionsData.Count; j++)
            {
                var result = String.Format("{0:G4}", sd[j]);
                row += $"{dataSample.ScoreOptionsData[j]}:{result};";
            }
            append += row + Environment.NewLine;
        }
        append.Trim(':');
        sr.WriteLineAsync(append);

    }

}