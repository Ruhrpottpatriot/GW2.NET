using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.ColorsInformation
{
    [TestFixture]
    public class DyeDetailsTest
    {
        private DyeDetails dyeDetails;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.dyeDetails = JsonConvert.DeserializeObject<DyeDetails>(input);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.dyeDetails.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_BaseRgbReflectsInput()
        {
            var expected = default(Color);
            var actual   = this.dyeDetails.BaseRGB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_ClothReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dyeDetails.Cloth;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_LeatherReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dyeDetails.Leather;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_MetalReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dyeDetails.Metal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void DyeDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dyeDetails.ExtensionData);
        }
    }
}
