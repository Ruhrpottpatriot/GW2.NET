using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.ColorsInformation
{
    [TestFixture]
    public class DyeTest
    {
        private Dye dye;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.dye = JsonConvert.DeserializeObject<Dye>(input);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_NameReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.dye.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_BaseRgbReflectsInput()
        {
            var expected = default(Color);
            var actual   = this.dye.BaseRgb;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_ClothReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dye.Cloth;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_LeatherReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dye.Leather;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_MetalReflectsInput()
        {
            var expected = new Material();
            var actual   = this.dye.Metal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void Dye_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dye.ExtensionData);
        }
    }
}
