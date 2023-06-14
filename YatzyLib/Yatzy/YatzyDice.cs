using YatzyLib;

public class D6 : IDice
{
    public bool Locked { get ; set ; }
    public int Val { get ; set ; }
    public int Max { get ; set ; }
    public D6()
    {
        Locked = false;
        Max = 6;
        Val = 1;
    }
}