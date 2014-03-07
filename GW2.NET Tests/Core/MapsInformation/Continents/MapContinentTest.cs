using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Common;
using GW2DotNET.V1.Core.MapsInformation.Continents;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Continents
{
    [TestFixture]
    public class MapContinentTest
    {
        private MapContinent mapContinent;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"continent_dims\":[],\"min_zoom\":0,\"max_zoom\":0,\"floors\":[]}";
            this.mapContinent = JsonConvert.DeserializeObject<MapContinent>(input);
        }

        [Test]
        [Category("continents.json")]
        public void MapContinent_ContinentNameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.mapContinent.ContinentName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void MapContinent_ContinentDimensionsReflectsInput()
        {
            var expected = default(Size);
            var actual   = this.mapContinent.ContinentDimensions;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void MapContinent_MinimumZoomReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapContinent.MinimumZoom;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void MapContinent_MaximumZoomReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.mapContinent.MaximumZoom;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void MapContinent_FloorsReflectsInput()
        {
            var expected = new MapFloorCollection();
            var actual   = this.mapContinent.Floors;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        [Category("ExtensionData")]
        public void MapContinent_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.mapContinent.ExtensionData);
        }
    }
}
