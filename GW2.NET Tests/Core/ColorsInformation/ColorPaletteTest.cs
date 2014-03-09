using GW2DotNET.V1.Core.ColorsInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ColorsInformation
{
    [TestFixture]
    public class ColorPaletteTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.color = JsonConvert.DeserializeObject<ColorPalette>(input);
        }

        private ColorPalette color;

        [Test]
        [Category("colors.json")]
        public void ColorPalette_BaseRgbReflectsInput()
        {
            System.Drawing.Color expected = default(System.Drawing.Color);
            System.Drawing.Color actual   = this.color.BaseRgb;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorPalette_ClothReflectsInput()
        {
            var expected      = new ColorModel();
            ColorModel actual = this.color.Cloth;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void ColorPalette_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.color.ExtensionData);
        }

        [Test]
        [Category("colors.json")]
        public void ColorPalette_LeatherReflectsInput()
        {
            var expected      = new ColorModel();
            ColorModel actual = this.color.Leather;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorPalette_MetalReflectsInput()
        {
            var expected      = new ColorModel();
            ColorModel actual = this.color.Metal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorPalette_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual   = this.color.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}