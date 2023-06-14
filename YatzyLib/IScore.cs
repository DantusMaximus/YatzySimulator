namespace YatzyLib;
public interface IScore
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Used { get; set; }
    public Func<int> ?SetScore { get; set; }
    public void Set();
}