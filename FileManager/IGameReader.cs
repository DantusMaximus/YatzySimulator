using YatzyLib;

namespace FileManager;
public interface IGameReader
{
    public string Path { get; set; }
    public IGame Read();
    public IGame ReadPlayers();

}
