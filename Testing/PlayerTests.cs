using NUnit.Framework;
using YatzyLib;
[TestFixture]
public class PlayerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ChooseScoringMethodTest()
    {
        List<IPlayer> p = new List<IPlayer>();
        IPlayer pl = new MockPlayer("Sven", 0);
        p.Add(pl);
        var mockGame = new MockGame(p);
        var dices = new List<IDice>();
        for(int i=1;i<=5;i++)
        {
            dices.Add(new D6());
        }
        IScoreLogic sl = new YatzyScoreLogic(dices);
        var init = new YatzyInitializer(sl);
        init.Initialize(mockGame);
        int rc = 0;
        pl.Roll(dices,ref rc);
        pl.ChooseScore(sl, "One");
        Assert.That(pl.Scores[0].Value,Is.EqualTo(sl.One()));
    }
}