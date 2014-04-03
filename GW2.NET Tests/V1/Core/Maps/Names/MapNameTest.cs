// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNameTest.cs" company="">
//   
// </copyright>
// <summary>
//   The map name test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Names
{
    using GW2DotNET.V1.Maps.Names.Types;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The map name test.</summary>
    [TestFixture]
    public class MapNameTest
    {
        /// <summary>The map name.</summary>
        private MapName mapName;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"ID\":\"0\",\"name\":\"\"}";
            this.mapName = JsonConvert.DeserializeObject<MapName>(input);
        }

        /// <summary>The map name_ extension data is empty.</summary>
        [Test]
        [Category("map_names.json")]
        [Category("ExtensionData")]
        public void MapName_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapName.ExtensionData);
        }

        /// <summary>The map name_ id reflects input.</summary>
        [Test]
        [Category("map_names.json")]
        public void MapName_IdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.mapName.Id;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The map name_ name reflects input.</summary>
        [Test]
        [Category("map_names.json")]
        public void MapName_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.mapName.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}