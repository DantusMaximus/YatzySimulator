using NUnit.Framework;
using YatzyLib;
[TestFixture]
public class ScoreLogicTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PlayerPlacementTest()
    {
        var r = new Random();
        List<IPlayer> actual = new List<IPlayer>();
        List<IPlayer> tested = new List<IPlayer>();

        for (int i = 0; i <= 100; i++)
        {
            string n = r.Next(1, 100).ToString();
            int v = r.Next(1, 100);
            IPlayer a = new MockPlayer(n, v);
            IPlayer t = new MockPlayer(n, v);
            actual.Add(a);
            tested.Add(t);
        }
        IScoreLogic s = new MockScoreLogic();
        tested = s.SetPlayerPlacements(tested);
        actual = (from p in actual orderby p.TotalScore descending select p).ToList();
        Assert.That(from t in tested select t.TotalScore, Is.EqualTo(from a in actual select a.TotalScore));
    }

    [Test]
    public void SetScoreTest()
    {
        List<IPlayer> players = new List<IPlayer>();
        IPlayer mp = new MockPlayer("Sven", 0);
        var vals = new int[] { 1, 1, 1, 1, 1 };
        List<IDice> dices = new List<IDice>();
        foreach (var v in vals)
        {
            dices.Add(new MockDice(6, v));
        }
        var mg = new MockGame(players);
        IScoreLogic sl = new YatzyScoreLogic(dices);
        IGameInitializer init = new SimulatedYatzyInitializer(sl);
        players.Add(mp);
        init.Initialize(mg);
        mp.ChooseScore(sl, "Y");
        Assert.That(mp.Scores[1].Value, Is.EqualTo(50));
    }
    [Test]
    public void YatzyScoreTest()
    {
        var vals = new int[] { 1, 1, 1, 1, 1 };
        List<IDice> dices = new List<IDice>();
        foreach (var v in vals)
        {
            dices.Add(new MockDice(6, v));
        }
        IScoreLogic sl = new YatzyScoreLogic(dices);
        Assert.That(sl.Yatzy(),Is.EqualTo(50));
    }
}