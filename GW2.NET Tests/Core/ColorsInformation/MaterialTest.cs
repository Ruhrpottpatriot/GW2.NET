using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.ColorsInformation
{
    [TestFixture]
    public class MaterialTest
    {
        private Material material;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"brightness\":0,\"contrast\":0,\"hue\":0,\"saturation\":0,\"lightness\":0,\"rgb\":[]}";
            this.material = JsonConvert.DeserializeObject<Material>(input);
        }

        [Test]
        [Category("colors.json")]
        public void Material_BrightnessReflectsInput()
        {
            const int expected = default(int);
            var actual         = material.Brightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ContrastReflectsInput()
        {
            const double expected = default(double);
            var actual            = material.Contrast;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_HueReflectsInput()
        {
            const int expected = default(int);
            var actual         = material.Hue;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_SaturationReflectsInput()
        {
            const double expected = default(double);
            var actual            = material.Saturation;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_LightnessReflectsInput()
        {
            const double expected = default(double);
            var actual            = material.Lightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_RgbReflectsInput()
        {
            var expected = default(Color);
            var actual   = material.RGB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void Material_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(material.ExtensionData);
        }
    }
}
