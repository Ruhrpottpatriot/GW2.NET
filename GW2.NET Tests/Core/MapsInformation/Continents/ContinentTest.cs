using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Common;
using GW2DotNET.V1.Core.MapsInformation.Continents;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Continents
{
    [TestFixture]
    public class ContinentTest
    {
        private Continent continent;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"continent_dims\":[],\"min_zoom\":0,\"max_zoom\":0,\"floors\":[]}";
            this.continent = JsonConvert.DeserializeObject<Continent>(input);
        }

        [Test]
        [Category("continents.json")]
        public void ContinentTest_ContinentNameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.continent.ContinentName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void ContinentTest_ContinentDimensionsReflectsInput()
        {
            var expected = default(Size);
            var actual   = this.continent.ContinentDimensions;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void ContinentTest_MinimumZoomReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.continent.MinimumZoom;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void ContinentTest_MaximumZoomReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.continent.MaximumZoom;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        public void ContinentTest_FloorsReflectsInput()
        {
            var expected = new FloorCollection();
            var actual   = this.continent.Floors;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("continents.json")]
        [Category("ExtensionData")]
        public void ContinentTest_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.continent.ExtensionData);
        }
    }
}
