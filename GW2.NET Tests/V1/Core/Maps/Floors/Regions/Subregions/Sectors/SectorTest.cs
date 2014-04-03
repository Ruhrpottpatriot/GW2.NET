// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorTest.cs" company="">
//   
// </copyright>
// <summary>
//   The sector test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.Sectors
{
    using System.Drawing;

    using GW2DotNET.V1.Maps.Floors.Types.Regions.Subregions.Sectors;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The sector test.</summary>
    [TestFixture]
    public class SectorTest
    {
        /// <summary>The sector.</summary>
        private Sector sector;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"sector_id\":0,\"name\":\"\",\"level\":0,\"coord\":[]}";
            this.sector = JsonConvert.DeserializeObject<Sector>(input);
        }

        /// <summary>The sector_ coordinates reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Sector_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.sector.Coordinates;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sector_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Sector_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.sector.ExtensionData);
        }

        /// <summary>The sector_ level reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Sector_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.sector.Level;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sector_ name reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Sector_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.sector.Name;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The sector_ sector id reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Sector_SectorIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.sector.SectorId;

            Assert.AreEqual(expected, actual);
        }
    }
}