using YatzyLib;
public class AIScoreMethods
{
    public void YatzyScoreMethod(IPlayer aiPlayer, IScoreLogic sl, List<IDice> dices, int rollCount)
    {
        foreach (var d in dices)
        {
            d.Locked = false;
        }
        int maxCount = 0;
        List<IDice> lockedDices = new List<IDice>();
        int timesRolled = 0;
        while (timesRolled < rollCount)
        {
            aiPlayer.Roll(dices, ref timesRolled);
            for (int i = 6; i >= 1; i--)
            {
                var candidate = dices.FindAll(o => o.Val == i);
                if (candidate.Count >= maxCount)
                {
                    foreach (var d in lockedDices)
                    {
                        d.Locked = false;
                    }
                    lockedDices.Clear();
                    lockedDices.AddRange(candidate);
                    maxCount = lockedDices.Count;
                    candidate.Clear();
                }
            }
            foreach (var d in lockedDices)
            {
                d.Locked = true;
            }
        }
        aiPlayer.ChooseScore(sl, "Y");
    }
    public void SmallStraightScoreMethod(IPlayer aiPlayer, IScoreLogic sl, List<IDice> dices, int rollCount)
    {
        List<IDice> lockedDices = new List<IDice>();
        int timesRolled = 0;
        foreach (var d in dices)
        {
            d.Locked = false;
        }
        while (timesRolled < rollCount)
        {
            aiPlayer.Roll(dices, ref timesRolled);
            for (int i = 5; i >= 1; i--)
            {
                var candidate = dices.FindAll(o => o.Val == i);
                if (lockedDices.FindAll(o => o.Val == i).ToList().Count < 1 && candidate.Count >= 1)
                {
                    lockedDices.Add(candidate[0]);
                    candidate.Clear();
                }
            }
            foreach (var d in lockedDices)
            {
                d.Locked = true;
            }
        }
        aiPlayer.ChooseScore(sl, "SS");
    }
}
public enum AIScoreMethodType
{
    Yatzy, SmallStraight
}