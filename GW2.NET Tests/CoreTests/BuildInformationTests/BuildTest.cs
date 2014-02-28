
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
            this.build = JsonConvert.DeserializeObject<Build>("{\"build_id\":30318}");
        }

        [Test]
        [Category("build.json")]
        public void Build_BuildIdReflectsInput()
        {
            Assert.AreEqual(30318, build.BuildId);
        }

        [Test]
        [Category("build.json")]
        public void Build_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(build.ExtensionData);
        }
    }
}
