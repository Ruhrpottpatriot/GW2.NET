using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ColorsInformation
{
    using Color = System.Drawing.Color;

    [TestFixture]
    public class ColorModelTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"brightness\":0,\"contrast\":0,\"hue\":0,\"saturation\":0,\"lightness\":0,\"rgb\":[]}";
            this.colorModel = JsonConvert.DeserializeObject<ColorModel>(input);
        }

        private ColorModel colorModel;

        [Test]
        [Category("colors.json")]
        public void ColorModel_BrightnessReflectsInput()
        {
            const int expected = default(int);
            int actual         = this.colorModel.Brightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorModel_ContrastReflectsInput()
        {
            const double expected = default(double);
            double actual         = this.colorModel.Contrast;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void ColorModel_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.colorModel.ExtensionData);
        }

        [Test]
        [Category("colors.json")]
        public void ColorModel_HueReflectsInput()
        {
            const int expected = default(int);
            int actual         = this.colorModel.Hue;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorModel_LightnessReflectsInput()
        {
            const double expected = default(double);
            double actual         = this.colorModel.Lightness;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorModel_RgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual   = this.colorModel.Rgb;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("colors.json")]
        public void ColorModel_SaturationReflectsInput()
        {
            const double expected = default(double);
            double actual         = this.colorModel.Saturation;

            Assert.AreEqual(expected, actual);
        }
    }
}