
using GW2DotNET.V1.Core.BuildInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.BuildInformationTests
{
    [TestFixture]
    public class BuildTest
    {
        private Build build;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"build_id\":30318}";
            this.build = JsonConvert.DeserializeObject<Build>(input);
        }

        [Test]
        [Category("build.json")]
        public void Build_BuildIdReflectsInput()
        {
            const int expectedBuildId = 30318;
            Assert.AreEqual(expectedBuildId, build.BuildId);
        }

        [Test]
        [Category("build.json")]
        [Category("ExtensionData")]
        public void Build_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(build.ExtensionData);
        }
    }
}
