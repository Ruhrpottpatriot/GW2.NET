using GW2DotNET.V1.Core.FilesInformation.Catalogs;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.FilesInformationTests
{
    [TestFixture]
    public class AssetTest
    {
        private Asset asset;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"file_id\":528724,\"signature\":\"5A4E663071250EC72668C09E3C082E595A380BF7\"}";
            this.asset = JsonConvert.DeserializeObject<Asset>(input);
        }

        [Test]
        [Category("files.json")]
        public void Asset_FileIdReflectsInput()
        {
            const int expectedFileId = 528724;
            Assert.AreEqual(expectedFileId, this.asset.FileId);
        }

        [Test]
        [Category("files.json")]
        public void Asset_SignatureReflectsInput()
        {
            const string expectedSignature = "5A4E663071250EC72668C09E3C082E595A380BF7";
            Assert.AreEqual(expectedSignature, this.asset.Signature);
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
