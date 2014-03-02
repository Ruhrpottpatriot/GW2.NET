using GW2DotNET.V1.Core.FilesInformation.Catalogs;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.FilesInformation
{
    [TestFixture]
    public class AssetTest
    {
        private Asset asset;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"file_id\":0,\"signature\":\"\"}";
            this.asset = JsonConvert.DeserializeObject<Asset>(input);
        }

        [Test]
        [Category("files.json")]
        public void Asset_FileIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.asset.FileId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("files.json")]
        public void Asset_SignatureReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.asset.Signature;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("files.json")]
        [Category("ExtensionData")]
        public void Asset_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.asset.ExtensionData);
        }
    }
}
