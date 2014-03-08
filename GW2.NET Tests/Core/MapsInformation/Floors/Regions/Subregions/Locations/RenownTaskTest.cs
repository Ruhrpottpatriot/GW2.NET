using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    [TestFixture]
    public class RenownTaskTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"task_id\":0,\"objective\":\"\",\"level\":0,\"coord\":[]}";
            this.renownTask = JsonConvert.DeserializeObject<RenownTask>(input);
        }

        private RenownTask renownTask;

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.renownTask.Coordinates;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void RenownTask_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.renownTask.ExtensionData);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.renownTask.Level;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_ObjectiveReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.renownTask.Objective;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("map_floor.json")]
        public void RenownTask_TaskIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.renownTask.TaskId;
            Assert.AreEqual(expected, actual);
        }
    }
}