namespace YatzyLib;
public interface IScoreLogic
{
    public List<IDice> Dices{get;set;}
    public int Top6(int Num)
    {
        int r = 0;
        foreach(var dice in Dices)
        {
            if(dice.Val == Num){r+=Num;}
        }
        return r;
    }
    private int NOfAKind(int n)
    {
        for(int i = 6;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count == n){return n*i;}
        }
        return 0;
    }
    public int One()
    {
        return Top6(1);
    }
    public int Two()
    {
        return Top6(2);
    }
    public int Three()
    {
        return Top6(3);
    }
    public int Four()
    {
        return Top6(4);
    }
    public int Five()
    {
        return Top6(5);
    }
    public int Six()
    {
        return Top6(6);
    }
    public int Pair()
    {
        return NOfAKind(2);
    }
    public int ThreeOfAKind()
    {
        return NOfAKind(3);
    }
    public int FourOfAKind()
    {
        return NOfAKind(4);
    }
    public int TwoPair()
    {
        int p1 = 0;
        for(int i = 6;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count == 2){p1 = i;}
        }
        for(int i = p1-1;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count == 2){return 2*p1 + 2*i;}
        }
        return 0;
    }
    public int House()
    {
        int t = 0;
        for(int i = 6;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count == 2){t = i;}
        }
        for(int i = 6;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count == 2 && i != t){return 3*t + 2*i;}
        }
        return 0;
    }
    private int StraightHelper(int points, int min, int max)
    {
        for(int i = min; i<=max; i++)
        {
            if(Dices.FindAll(o => o.Val == i).Count < 1){return 0;}
        }
        return points;
    }
    public int SmallStraight()
    {
        return StraightHelper(15,1,5);
    }
    public int LargeStraight()
    {
        return StraightHelper(20,2,6);
    }
    public int Yatzy()
    {
        for(int i = 6;i>=1;i--)
        {
            if(Dices.FindAll(o => o.Val == i).Count >= 5){return 50;}
        }
        return 0;
    }
    public int Chance()
    {
        int r = 0;
        foreach(var dice in Dices)
        {
            r += dice.Val;
        }
        return r;
    }
    public List<IPlayer> SetPlayerPlacements(List<IPlayer> players)
    {
        return (from p in players orderby p.TotalScore descending select p).ToList();
    }
    public bool SetScore(IPlayer p, string scoreOption)
    {
        foreach(var s in p.Scores)
        {
            if(scoreOption == s.Name && !s.Used)
            {
                s.Set();
                return true;
            }
        }
        return false;
    }

}