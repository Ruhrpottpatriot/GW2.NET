using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ItemsInformationTests.DetailsTests.ItemsTests
{
    [TestFixture]
    public class GameTypesTest
    {
        [Test]
        [Category("item_details.json")]
        public void GameTypes_None_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.None;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_Activity_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Activity\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.Activity;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_Dungeon_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Dungeon\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.Dungeon;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_PvE_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Pve\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.PvE;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_PvP_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Pvp\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.PvP;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_PvPLobby_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"PvpLobby\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.PvPLobby;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_WvW_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Wvw\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.WvW;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void GameTypes_Multiple_GameTypesReflectsInput()
        {
            const string input                = "{\"game_types\":[\"Activity\",\"Dungeon\",\"Pve\",\"Wvw\"]}";
            var item                          = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameTypes expectedGameTypes = GameTypes.Activity | GameTypes.Dungeon | GameTypes.PvE | GameTypes.WvW;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

    }
}
