namespace YatzyLib;
public interface IDice
{
    public bool Locked {get;set;}
    public int Val {get;set;}
    public int Max {get;set;}
    public void Roll()
    {
        var random = new Random();
        this.Val = random.Next(1,Max+1);
        return;
    }
    public void Toggle()
    {
        this.Locked = ! this.Locked;
    }
}