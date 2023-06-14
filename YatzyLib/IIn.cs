namespace YatzyLib;
public interface IIn
{
    public PlayerOption GetInput();
    public bool Valid(PlayerOption option);
    public void Toggle(List<IDice> dices, IOut o);//ON/OFF
    public string GetScoreOption();
    public string GetPlayerName();
}