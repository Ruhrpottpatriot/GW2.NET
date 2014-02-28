using System.Drawing;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ColorsInformation
{
    [TestFixture]
    public class DyeDetailsTest
    {
        private DyeDetails dyeDetails;

        [SetUp]
        public void Initialize()
        {
            this.dyeDetails =
                JsonConvert.DeserializeObject<DyeDetails>("{\"name\":\"Hot Pink\",\"base_rgb\":[128,26,26]}");
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_NameReflectsInput()
        {
            Assert.AreEqual("Hot Pink", this.dyeDetails.Name);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_BaseRgbReflectsInput()
        {
            var baseRgb = Color.FromArgb(128, 26, 26);
            Assert.AreEqual(baseRgb, this.dyeDetails.BaseRGB);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dyeDetails.ExtensionData);
        }
    }
}
