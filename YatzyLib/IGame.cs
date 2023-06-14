namespace YatzyLib;
public interface IGame
{
    public string GameType { get; set; }
    public List<IPlayer> Players {get;set;}
    public IScoreLogic ScoreLogic{get;set;}
    public int RollCount { get; set; }
    public int Rounds { get; set; }
    public void RunGame()
    {
        int roundsLeft = Rounds;
        while(roundsLeft>0)
        {
            foreach(var player in Players)
            {
                player.DoTurn(this.ScoreLogic, ScoreLogic.Dices, RollCount);
            }
            roundsLeft--;
        }
        EndGame();
    }
    private void EndGame()
    {
        foreach(var p in Players)
        {
            p.SetTotalScore();
        }
        ScoreLogic.SetPlayerPlacements(Players);
        foreach(var p in Players)
        {
            p.GameOver(this);
        }
    }

    public bool GameOver()
    {
        return Players[0].Scores.FindAll(o => o.Used == false).Count == 0;
    }
}