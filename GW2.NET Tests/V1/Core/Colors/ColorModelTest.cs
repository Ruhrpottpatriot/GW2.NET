// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelTest.cs" company="">
//   
// </copyright>
// <summary>
//   The color model test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Colors
{
    using System.Drawing;

    using GW2DotNET.V1.Colors.Types;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The color model test.</summary>
    [TestFixture]
    public class ColorModelTest
    {
        /// <summary>The color model.</summary>
        private ColorModel colorModel;

        /// <summary>The color model_ brightness reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_BrightnessReflectsInput()
        {
            const int expected = default(int);
            int actual = this.colorModel.Brightness;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color model_ contrast reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_ContrastReflectsInput()
        {
            const double expected = default(double);
            double actual = this.colorModel.Contrast;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color model_ extension data is empty.</summary>
        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void ColorModel_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.colorModel.ExtensionData);
        }

        /// <summary>The color model_ hue reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_HueReflectsInput()
        {
            const int expected = default(int);
            int actual = this.colorModel.Hue;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color model_ lightness reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_LightnessReflectsInput()
        {
            const double expected = default(double);
            double actual = this.colorModel.Lightness;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color model_ rgb reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_RgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual = this.colorModel.Rgb;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color model_ saturation reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorModel_SaturationReflectsInput()
        {
            const double expected = default(double);
            double actual = this.colorModel.Saturation;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"brightness\":0,\"contrast\":0,\"hue\":0,\"saturation\":0,\"lightness\":0,\"rgb\":[]}";
            this.colorModel = JsonConvert.DeserializeObject<ColorModel>(input);
        }
    }
}