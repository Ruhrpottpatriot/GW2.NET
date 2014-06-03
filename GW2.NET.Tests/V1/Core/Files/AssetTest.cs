// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetTest.cs" company="">
//   
// </copyright>
// <summary>
//   The asset test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Files
{
    using GW2DotNET.V1.Files.Contracts;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The asset test.</summary>
    [TestFixture]
    public class AssetTest
    {
        /// <summary>The asset.</summary>
        private Asset asset;

        /// <summary>The asset_ extension data is empty.</summary>
        [Test]
        [Category("files.json")]
        [Category("ExtensionData")]
        public void Asset_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.asset.ExtensionData);
        }

        /// <summary>The asset_ file id reflects input.</summary>
        [Test]
        [Category("files.json")]
        public void Asset_FileIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.asset.FileId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The asset_ signature reflects input.</summary>
        [Test]
        [Category("files.json")]
        public void Asset_SignatureReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.asset.FileSignature;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"file_id\":0,\"signature\":\"\"}";
            this.asset = JsonConvert.DeserializeObject<Asset>(input);
        }
    }
}