using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class SectorTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"sector_id\":0,\"name\":\"\",\"level\":0,\"coord\":[]}";
            this.sector = JsonConvert.DeserializeObject<Sector>(input);
        }

        private Sector sector;

        [Test]
        [Category("map_floor.json")]
        public void Sector_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.sector.Coordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Sector_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.sector.ExtensionData);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.sector.Level;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.sector.Name;

            Assert.AreEqual(expected, actual);
        }

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