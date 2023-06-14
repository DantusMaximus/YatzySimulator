using YatzyLib;

public class Dice : IDice
{
    public bool Locked { get ; set ; }
    public int Val { get ; set ; }
    public int Max { get ; set ; }
    public Dice(bool locked, int val, int max){
        Locked = locked;
        Val = val;
        Max = max;
    }
}