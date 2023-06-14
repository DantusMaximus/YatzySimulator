using YatzyLib;
public class MockDice : IDice
{
    public bool Locked {get;set;}
    public int Val {get;set;}
    public int Max {get;set;}
    public int Num { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public MockDice(int max, int val)
    {
        this.Val = val;
    }
}