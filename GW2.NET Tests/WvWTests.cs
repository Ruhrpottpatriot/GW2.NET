using System.Diagnostics;

using GW2DotNET.WvW;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    [TestFixture]
    public class WvWTests
    {
        private MatchData matchData;

        [SetUp]
        public void Init()
        {
            matchData = new MatchData();
        }

        [Test]
        public void GetAllMatches()
        {
            var matchList = matchData.GetMatches();

            Assert.IsFalse(matchList == null);
        }

        [Test]
        public void GetOneMatch(string MatchID)
        {
            var matchDetails = matchData.GetMatchDetails(MatchID);

            Assert.IsFalse(matchDetails == null);
        }
    }
}
