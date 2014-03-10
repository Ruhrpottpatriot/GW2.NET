// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteTest.cs" company="">
//   
// </copyright>
// <summary>
//   The color palette test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.ColorsInformation
{
    using System.Drawing;

    using GW2DotNET.V1.Core.ColorsInformation;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The color palette test.</summary>
    [TestFixture]
    public class ColorPaletteTest
    {
        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.color = JsonConvert.DeserializeObject<ColorPalette>(input);
        }

        /// <summary>The color.</summary>
        private ColorPalette color;

        /// <summary>The color palette_ base rgb reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_BaseRgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual = this.color.BaseRgb;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ cloth reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_ClothReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.color.Cloth;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ extension data is empty.</summary>
        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void ColorPalette_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.color.ExtensionData);
        }

        /// <summary>The color palette_ leather reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_LeatherReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.color.Leather;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ metal reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_MetalReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.color.Metal;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ name reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.color.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}