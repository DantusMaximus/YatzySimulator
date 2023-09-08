// See https://aka.ms/new-console-template for more information
using YatzyLib;
using YatzySimulator;
using FileManager;
List<IPlayer> players = new List<IPlayer>();
var output = new Output();
players.Add(new AIPlayer("Henry", AIScoreMethodType.SmallStraight, output));
players.Add(new AIPlayer("Sven", AIScoreMethodType.Yatzy, output));
//Studera  DiceCount eller RollCount eller Rounds
int dc = 5;
int rc = 3;
int r = 14;
IGame game = new SimulatedYatzy(players, dc, 6, rc, r, false);
var smw1 = new SimulatedYatzyWriter(@"YatzyLib\Yatzy\SavedGame.json");
var sampler = new DataSampler(game);
var sample = sampler.CollectDataSample(SampleType.Rounds,100,14,14);
smw1.Sample(@"..\YatzySimulator\SampleData",sample);
//var smr = new SimulatedYatzyReader("../YatzySimulator/SaveFile.json");
//var game = smr.Read();