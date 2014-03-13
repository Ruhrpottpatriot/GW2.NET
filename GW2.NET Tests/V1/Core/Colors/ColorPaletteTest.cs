// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteTest.cs" company="">
//   
// </copyright>
// <summary>
//   The color palette test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Colors
{
    using System.Drawing;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The color palette test.</summary>
    [TestFixture]
    public class ColorPaletteTest
    {
        /// <summary>The colorPalette.</summary>
        private ColorPalette colorPalette;

        /// <summary>The color palette_ base rgb reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_BaseRgbReflectsInput()
        {
            Color expected = default(Color);
            Color actual = this.colorPalette.BaseRgb;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ cloth reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_ClothReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.colorPalette.Cloth;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ extension data is empty.</summary>
        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void ColorPalette_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.colorPalette.ExtensionData);
        }

        /// <summary>TODO The color palette_ leather color palette is this.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_LeatherColorPaletteIsThis()
        {
            var expected = this.colorPalette;
            var actual = this.colorPalette.Leather.ColorPalette;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ leather reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_LeatherReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.colorPalette.Leather;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>TODO The color palette_ metal color palette is this.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_MetalColorPaletteIsThis()
        {
            var expected = this.colorPalette;
            var actual = this.colorPalette.Metal.ColorPalette;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ metal reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_MetalReflectsInput()
        {
            var expected = new ColorModel();
            ColorModel actual = this.colorPalette.Metal;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The color palette_ name reflects input.</summary>
        [Test]
        [Category("colors.json")]
        public void ColorPalette_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.colorPalette.Name;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"base_rgb\":[],\"cloth\":{},\"leather\":{},\"metal\":{}}";
            this.colorPalette = JsonConvert.DeserializeObject<ColorPalette>(input);
        }
    }
}