using YatzyLib;

public class MockInput : IIn
{
    public PlayerOption GetInput()
    {
        throw new NotImplementedException();
    }

    public string GetPlayerName()
    {
        throw new NotImplementedException();
    }

    public string GetScoreOption()
    {
        throw new NotImplementedException();
    }

    public void Toggle(List<IDice> dices, IOut o)
    {
        throw new NotImplementedException();
    }

    public bool Valid(PlayerOption option)
    {
        throw new NotImplementedException();
    }
}