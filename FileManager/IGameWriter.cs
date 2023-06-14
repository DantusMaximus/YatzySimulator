using YatzyLib;

public interface IGameWriter
{
    public string Path { get; set; }
    public void Write(IGame game);
}