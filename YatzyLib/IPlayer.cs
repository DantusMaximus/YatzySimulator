namespace YatzyLib;
public interface IPlayer
{
    public string Name { get; set; }
    public List<IScore> Scores { get; set; }
    public int TotalScore { get; set; }
    public IIn Input { get; set; }
    public IOut Output { get; set; }
    public bool ChooseScore(IScoreLogic sl, string scoreOption)
    {
        return sl.SetScore(this, scoreOption);
    }
    public void Roll(List<IDice> dices, ref int rollCount)
    {

        foreach (var d in dices)
        {
            if (!d.Locked) d.Roll();
        }
        rollCount++;
    }
    public void SetTotalScore()
    {
        this.TotalScore = 0;
        foreach (var s in Scores)
        {
            this.TotalScore += s.Value;
        }
    }
    public void DoTurn(IScoreLogic sl, List<IDice> dices, int rollCount)
    {
        int rolledCount = 0;
        PlayerOption option;
        while(rolledCount<rollCount)
        {
            Output.ShowDice(dices);
            option = this.Input.GetInput();
            this.PerformTask(option, dices, rollCount, sl, ref rolledCount);
            if(option == PlayerOption.Score){return;}
        }
        throw new NotImplementedException();
    }
    public void PerformTask(PlayerOption option, List<IDice> dices, int rollCount, IScoreLogic sl, ref int rolledCount)
    {
        if(option == PlayerOption.Roll && rolledCount < rollCount){Roll(dices, ref rolledCount);}
        if(option == PlayerOption.Lock && rolledCount != 0){Input.Toggle(dices, Output);}
        if(option == PlayerOption.Score)
        {this.ChooseScore(sl, this.Input.GetScoreOption());}
    }
    public void GameOver(IGame game)
    {
        if(Output == null){return;}
        Output.GameOver(game);
    }
}