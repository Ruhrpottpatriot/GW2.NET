using GW2DotNET.V1.Core.ErrorInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ErrorInformation
{
    [TestFixture]
    public class ErrorResultTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"error\":0,\"product\":0,\"module\":0,\"line\":0,\"text\":\"\"}";
            this.errorResult = JsonConvert.DeserializeObject<ErrorResult>(input);
        }

        private ErrorResult errorResult;

        [Test]
        [Category("errors")]
        public void ErrorResult_ErrorReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Error;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        [Category("ExtensionData")]
        public void ErrorResult_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.errorResult.ExtensionData);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ModuleReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Module;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_ProductReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Product;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("errors")]
        public void ErrorResult_TextReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.errorResult.Text;

            Assert.AreEqual(expected, actual);
        }
    }
}