using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class RenownTaskTest
    {
        private RenownTask renownTask;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"task_id\":0,\"objective\":\"\",\"level\":0,\"coord\":[]}";
            this.renownTask = JsonConvert.DeserializeObject<RenownTask>(input);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_TaskIdReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.renownTask.TaskId;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_ObjectiveReflectsInput()
        {
            var expected = string.Empty;
            var actual   = this.renownTask.Objective;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_LevelReflectsInput()
        {
            const int expected = default(int);
            var actual         = this.renownTask.Level;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_CoordinatesReflectsInput()
        {
            var expected = default(PointF);
            var actual   = this.renownTask.Coordinates;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void RenownTask_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.renownTask.ExtensionData);
        }
    }
}
