using YatzyLib;

public class YatzyScore : IScore
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Used { get; set; }
    public Func<int> ?SetScore { get;set;}
    public YatzyScore(string name, Func<int> setScore)
    {
        Name = name;
        Value = 0;
        Used = false;
        SetScore = setScore;
    }
    public void Set()
    {
        if(SetScore == null){throw new NullReferenceException();}
        this.Value = this.SetScore();
        this.Used = true;
    }
}