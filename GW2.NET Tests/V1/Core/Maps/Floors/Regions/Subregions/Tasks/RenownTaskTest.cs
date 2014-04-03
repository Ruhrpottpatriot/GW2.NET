// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskTest.cs" company="">
//   
// </copyright>
// <summary>
//   The renown task test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions.Tasks
{
    using System.Drawing;

    using GW2DotNET.V1.Maps.Floors.Types.Regions.Subregions.Tasks;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The renown task test.</summary>
    [TestFixture]
    public class RenownTaskTest
    {
        /// <summary>The renown task.</summary>
        private RenownTask renownTask;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"task_id\":0,\"objective\":\"\",\"level\":0,\"coord\":[]}";
            this.renownTask = JsonConvert.DeserializeObject<RenownTask>(input);
        }

        /// <summary>The renown task_ coordinates reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void RenownTask_CoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.renownTask.Coordinates;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The renown task_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void RenownTask_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.renownTask.ExtensionData);
        }

        /// <summary>The renown task_ level reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void RenownTask_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.renownTask.Level;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The renown task_ objective reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void RenownTask_ObjectiveReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.renownTask.Objective;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>The renown task_ task id reflects input.</summary>
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