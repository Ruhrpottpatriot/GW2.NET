// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResultTest.cs" company="">
//   
// </copyright>
// <summary>
//   The error result test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Core.ErrorInformation
{
    using GW2DotNET.V1.Core.ErrorInformation;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The error result test.</summary>
    [TestFixture]
    public class ErrorResultTest
    {
        /// <summary>The error result.</summary>
        private ErrorResult errorResult;

        /// <summary>The error result_ error reflects input.</summary>
        [Test]
        [Category("errors")]
        public void ErrorResult_ErrorReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Error;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The error result_ extension data is empty.</summary>
        [Test]
        [Category("errors")]
        [Category("ExtensionData")]
        public void ErrorResult_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.errorResult.ExtensionData);
        }

        /// <summary>The error result_ module reflects input.</summary>
        [Test]
        [Category("errors")]
        public void ErrorResult_ModuleReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Module;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The error result_ product reflects input.</summary>
        [Test]
        [Category("errors")]
        public void ErrorResult_ProductReflectsInput()
        {
            const int expected = default(int);
            int actual = this.errorResult.Product;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The error result_ text reflects input.</summary>
        [Test]
        [Category("errors")]
        public void ErrorResult_TextReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.errorResult.Text;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"error\":0,\"product\":0,\"module\":0,\"line\":0,\"text\":\"\"}";
            this.errorResult = JsonConvert.DeserializeObject<ErrorResult>(input);
        }
    }
}