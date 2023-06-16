using YatzyLib;

public class Output : IOut
{
    public bool Used { get; set; }
    public Output()
    {
        Used = false;
    }
    public void GameOver(IGame game)
    {
      //  if (!Used)
       // {
            foreach (var p in game.Players)
            {
                if(p.GetType() == typeof(AIPlayer)){continue;}
                AIPlayer aip = (AIPlayer)p;
                if (aip.ScoringType == AIScoreMethodType.Yatzy)
                {
                    Console.WriteLine(p.Name + "\tScore:" + p.TotalScore + "\tYatzys:" + p.TotalScore / 50);
                }
                if (aip.ScoringType == AIScoreMethodType.SmallStraight)
                {
                    Console.WriteLine(p.Name + "\tScore:" + p.TotalScore + "\tStraights:" + p.TotalScore / 15);
                }

            }
        //}
        Used = true;
    }

    public void PromptPlayer(string name)
    {
        throw new NotImplementedException();
    }

    public void ShowDice(List<IDice> dices)
    {
        string output = "";
        foreach (var d in dices)
        {
            output += (d.Val + ", ");
        }
        output.Trim(' ');
        output.Trim(',');
        Console.WriteLine(output);
    }
}