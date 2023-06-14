namespace YatzyLib;
public interface IOut
{
    public void PromptPlayer(string name);
    public void GameOver(IGame game);
    public void ShowDice(List<IDice> dices);
}