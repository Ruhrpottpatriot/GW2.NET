using GW2DotNET.V1.Core.ErrorInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ErrorInformationTests
{
    [TestFixture]
    public class ErrorResultTest
    {
        private ErrorResult errorResult;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"error\":1,\"product\":1,\"module\":1,\"line\":1,\"text\":\"error\"}";
            this.errorResult = JsonConvert.DeserializeObject<ErrorResult>(input);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ErrorReflectsInput()
        {
            const int expectedError = 1;
            Assert.AreEqual(expectedError, this.errorResult.Error);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ProductReflectsInput()
        {
            const int expectedProduct = 1;
            Assert.AreEqual(expectedProduct, this.errorResult.Product);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ModuleReflectsInput()
        {
            const int expectedModule = 1;
            Assert.AreEqual(expectedModule, this.errorResult.Module);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_TextReflectsInput()
        {
            const string expectedText = "error";
            Assert.AreEqual(expectedText, this.errorResult.Text);
        }

        [Test]
        [Category("errors")]
        [Category("ExtensionData")]
        public void ErrorResult_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.errorResult.ExtensionData);
        }
    }
}
