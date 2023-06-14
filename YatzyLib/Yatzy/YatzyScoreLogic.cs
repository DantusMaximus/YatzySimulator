namespace YatzyLib;
public class YatzyScoreLogic : IScoreLogic
{
    public int DiceCount { get; set; }
    public List<IDice> Dices { get; set; }

    public YatzyScoreLogic(List<IDice> dices)
    {
        Dices = dices;
    }
}