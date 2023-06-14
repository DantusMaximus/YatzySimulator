using YatzyLib;

public class Input : IIn
{
    private bool Valid(string input)
    {
        throw new System.NotImplementedException();
    }
    public PlayerOption GetInput()
    {
        string ?input = "";
        input = Console.ReadKey().ToString();
        if (input == "l") { return PlayerOption.Lock; }
        if (input == "r") { return PlayerOption.Roll; }
        if (input == "s") { return PlayerOption.Score; }
        if (input == "c") { return PlayerOption.Cancel; }
        return GetInput();
        throw new NotImplementedException();
    }
    public void Toggle(List<IDice> dices, IOut o)
    {
        int diceCount = dices.Count;
        string ?input = "";
        do
        {
            o.ShowDice(dices);
            input = Console.ReadKey().ToString();
            if(input == "c"){break;}
            int r = 0;
            if(!int.TryParse(input, out r)){continue;}
            if(r<0 || r>=diceCount){continue;}
            dices[r].Toggle();
        }
        while(input != "c");

    }
    public string GetScoreOption()
    {
        throw new NotImplementedException();
    }
    private bool ValidScoreMethod(PlayerOption o)
    {
        if (o == PlayerOption.Roll || o == PlayerOption.Lock) { return false; }
        return true;
    }

    public void Prompt()
    {
        throw new NotImplementedException();
    }

    public PlayerOption GetInput(int rollCount)
    {
        throw new NotImplementedException();
    }

    public bool Valid(PlayerOption option)
    {
        throw new NotImplementedException();
    }

    public string GetPlayerName()
    {
        string ?playerInput = Console.ReadLine();
        if(playerInput == null){throw new System.NullReferenceException();}
        playerInput.Trim();
        return playerInput;
    }
}