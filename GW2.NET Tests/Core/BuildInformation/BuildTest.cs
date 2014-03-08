using GW2DotNET.V1.Core.BuildInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.BuildInformation
{
    [TestFixture]
    public class BuildTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"build_id\":0}";
            this.build = JsonConvert.DeserializeObject<Build>(input);
        }

        private Build build;

        [Test]
        [Category("build.json")]
        public void Build_BuildIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.build.BuildId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("build.json")]
        [Category("ExtensionData")]
        public void Build_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.build.ExtensionData);
        }
    }
}