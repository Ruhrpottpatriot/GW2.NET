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
            const string input = "{\"name\":\"Hot Pink\",\"base_rgb\":[128,26,26]}";
            this.dyeDetails = JsonConvert.DeserializeObject<DyeDetails>(input);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_NameReflectsInput()
        {
            const string expectedName = "Hot Pink";
            Assert.AreEqual(expectedName, this.dyeDetails.Name);
        }

        [Test]
        [Category("colors.json")]
        public void DyeDetails_BaseRgbReflectsInput()
        {
            var expectedBaseRgb = Color.FromArgb(128, 26, 26);
            Assert.AreEqual(expectedBaseRgb, this.dyeDetails.BaseRGB);
        }

        [Test]
        [Category("colors.json")]
        [Category("ExtensionData")]
        public void DyeDetails_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.dyeDetails.ExtensionData);
        }
    }
}
