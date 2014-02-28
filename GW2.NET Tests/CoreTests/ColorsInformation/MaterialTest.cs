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
            this.material = JsonConvert.DeserializeObject<Material>("{\"brightness\":14,\"contrast\":1.21094,\"hue\":340,\"saturation\":0.820313,\"lightness\":1.44531,\"rgb\":[169,54,94]}");
        }

        [Test]
        [Category("colors.json")]
        public void Material_BrightnessReflectsInput()
        {
            Assert.AreEqual(14, material.Brightness);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ContrastReflectsInput()
        {
            Assert.AreEqual(1.21094, material.Contrast);
        }

        [Test]
        [Category("colors.json")]
        public void Material_HueReflectsInput()
        {
            Assert.AreEqual(340, material.Hue);
        }

        [Test]
        [Category("colors.json")]
        public void Material_SaturationReflectsInput()
        {
            Assert.AreEqual(0.820313, material.Saturation);
        }

        [Test]
        [Category("colors.json")]
        public void Material_LightnessReflectsInput()
        {
            var rgb = Color.FromArgb(169, 54, 94);
            Assert.AreEqual(rgb, material.RGB);
        }

        [Test]
        [Category("colors.json")]
        public void Material_RgbReflectsInput()
        {
            Assert.AreEqual(1.44531, material.Lightness);
        }

        [Test]
        [Category("colors.json")]
        public void Material_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(material.ExtensionData);
        }
    }
}
