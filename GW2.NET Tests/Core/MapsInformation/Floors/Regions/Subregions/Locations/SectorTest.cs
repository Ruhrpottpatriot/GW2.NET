using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class SectorTest
    {
        private Sector sector;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"sector_id\":0,\"name\":\"\",\"level\":0,\"coord\":[]}";
            this.sector = JsonConvert.DeserializeObject<Sector>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_SectorIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.sector.SectorId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.sector.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_LevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.sector.Level;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void Sector_CoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.sector.Coordinates;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Sector_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.sector.ExtensionData);
        }
    }
}
