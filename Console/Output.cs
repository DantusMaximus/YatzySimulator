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
                ConsolePlayer cp = (ConsolePlayer)p;
                Console.WriteLine($"{cp.Name} got {cp.TotalScore} total score");
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