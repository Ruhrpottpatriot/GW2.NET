using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ColorsInformation
{
    [TestFixture]
    public class MaterialTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"brightness\":0,\"contrast\":0,\"hue\":0,\"saturation\":0,\"lightness\":0,\"rgb\":[]}";
            this.material = JsonConvert.DeserializeObject<Material>(input);
        }

        private Material material;

        [Test]
        [Category("colors.json")]
        public void Material_BrightnessReflectsInput()
        {
            const int expected = default(int);
            int actual = this.material.Brightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ContrastReflectsInput()
        {
            const double expected = default(double);
            double actual = this.material.Contrast;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void Material_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.material.ExtensionData);
        }

        [Test]
        [Category("colors.json")]
        public void Material_HueReflectsInput()
        {
            const int expected = default(int);
            int actual = this.material.Hue;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_LightnessReflectsInput()
        {
            const double expected = default(double);
            double actual = this.material.Lightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_RgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual = this.material.Rgb;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void Material_SaturationReflectsInput()
        {
            const double expected = default(double);
            double actual = this.material.Saturation;

            Assert.AreEqual(expected, actual);
        }
    }
}