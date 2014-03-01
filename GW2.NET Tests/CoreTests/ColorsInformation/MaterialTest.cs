using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ColorsInformation
{
    [TestFixture]
    public class MaterialTest
    {
        private Material material;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"brightness\":14,\"contrast\":1.21094,\"hue\":340,\"saturation\":0.820313,\"lightness\":1.44531,\"rgb\":[169,54,94]}";
            this.material = JsonConvert.DeserializeObject<Material>(input);
        }

        [Test]
        [Category("colors.json")]
        public void Material_BrightnessReflectsInput()
        {
            const int expectedBrightness = 14;
            Assert.AreEqual(expectedBrightness, material.Brightness);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ContrastReflectsInput()
        {
            const double expectedContrast = 1.21094;
            Assert.AreEqual(expectedContrast, material.Contrast);
        }

        [Test]
        [Category("colors.json")]
        public void Material_HueReflectsInput()
        {
            const int expectedHue = 340;
            Assert.AreEqual(expectedHue, material.Hue);
        }

        [Test]
        [Category("colors.json")]
        public void Material_SaturationReflectsInput()
        {
            const double expectedSaturation = 0.820313;
            Assert.AreEqual(expectedSaturation, material.Saturation);
        }

        [Test]
        [Category("colors.json")]
        public void Material_LightnessReflectsInput()
        {
            const double expectedLightness = 1.44531;
            Assert.AreEqual(expectedLightness, material.Lightness);
        }

        [Test]
        [Category("colors.json")]
        public void Material_RgbReflectsInput()
        {
            var expectedRgb = Color.FromArgb(169, 54, 94);
            Assert.AreEqual(expectedRgb, material.RGB);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(material.ExtensionData);
        }
    }
}
