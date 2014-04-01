// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameRestrictionsTest.cs" company="">
//   
// </copyright>
// <summary>
//   The game types test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details
{
    using GW2DotNET.V1.ItemsDetails.Types;
    using GW2DotNET.V1.ItemsDetails.Types.ItemTypes;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The game restrictions test.</summary>
    [TestFixture]
    public class GameRestrictionsTest
    {
        /// <summary>TODO The game restrictions_ activity_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_Activity_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Activity\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.Activity;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ dungeon_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_Dungeon_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Dungeon\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.Dungeon;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ multiple_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_Multiple_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Activity\",\"Dungeon\",\"Pve\",\"Wvw\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.Activity | GameRestrictions.Dungeon | GameRestrictions.PvE | GameRestrictions.WvW;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ none_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_None_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.None;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ pv e_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_PvE_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Pve\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.PvE;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ pv p lobby_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_PvPLobby_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"PvpLobby\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.PvPLobby;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ pv p_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_PvP_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Pvp\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.PvP;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }

        /// <summary>TODO The game restrictions_ wv w_ game restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void GameRestrictions_WvW_GameRestrictionsReflectsInput()
        {
            const string input = "{\"game_types\":[\"Wvw\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const GameRestrictions expectedGameTypes = GameRestrictions.WvW;

            Assert.AreEqual(expectedGameTypes, item.GameTypes);
        }
    }
}