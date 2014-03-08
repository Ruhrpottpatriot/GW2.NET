using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ColorsInformation
{
    [TestFixture]
    public class DyeTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.dye = JsonConvert.DeserializeObject<Dye>(input);
        }

        private Dye dye;

        [Test]
        [Category("colors.json")]
        public void Dye_BaseRgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual = this.dye.BaseRgb;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_ClothReflectsInput()
        {
            var expected = new Material();
            Material actual = this.dye.Cloth;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void Dye_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dye.ExtensionData);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_LeatherReflectsInput()
        {
            var expected = new Material();
            Material actual = this.dye.Leather;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_MetalReflectsInput()
        {
            var expected = new Material();
            Material actual = this.dye.Metal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Dye_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.dye.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}