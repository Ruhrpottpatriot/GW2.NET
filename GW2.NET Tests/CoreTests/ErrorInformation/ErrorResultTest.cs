using GW2DotNET.V1.Core.ErrorInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ErrorInformation
{
    [TestFixture]
    public class ErrorResultTest
    {
        private ErrorResult errorResult;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"error\":0,\"product\":0,\"module\":0,\"line\":0,\"text\":\"\"}";
            this.errorResult = JsonConvert.DeserializeObject<ErrorResult>(input);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ErrorReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.errorResult.Error;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ProductReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.errorResult.Product;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ModuleReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.errorResult.Module;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_TextReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.errorResult.Text;

            Assert.AreEqual(expected, actual);
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
