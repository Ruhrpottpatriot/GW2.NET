// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildTest.cs" company="">
//   
// </copyright>
// <summary>
//   The build test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.BuildInformation
{
    using GW2DotNET.V1.Core.BuildInformation;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The build test.</summary>
    [TestFixture]
    public class BuildTest
    {
        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"build_id\":0}";
            this.build = JsonConvert.DeserializeObject<Build>(input);
        }

        /// <summary>The build.</summary>
        private Build build;

        /// <summary>The build_ build id reflects input.</summary>
        [Test]
        [Category("build.json")]
        public void Build_BuildIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.build.BuildId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The build_ extension data is empty.</summary>
        [Test]
        [Category("build.json")]
        [Category("ExtensionData")]
        public void Build_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.build.ExtensionData);
        }
    }
}