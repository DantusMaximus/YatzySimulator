using YatzyLib;

public class SimulatedScore : IScore
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Used { get; set; }
    public bool UseScore { get; set; }
    public int TimesGotten { get; set; }
    public Func<int> ?SetScore { get;set;}
    public SimulatedScore(string name, Func<int> setScore, bool useScore)
    {
        Name = name;
        Value = 0;
        UseScore = useScore;
        TimesGotten = 0;
        SetScore = setScore;
    }

    public void Set()
    {
        if(SetScore == null){throw new System.NullReferenceException();}
        if(SetScore() != 0){TimesGotten++;}
        this.Value += SetScore();
        if (!UseScore)
        {
            return;
        }
        this.Used = true;
    }
}