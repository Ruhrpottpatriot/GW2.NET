// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentTest.cs" company="">
//   
// </copyright>
// <summary>
//    The continent test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.MapsInformation.Continents
{
    using System.Drawing;

    using GW2DotNET.V1.Core.MapsInformation.Common;
    using GW2DotNET.V1.Core.MapsInformation.Continents;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The continent test.</summary>
    [TestFixture]
    public class ContinentTest
    {
        #region Fields

        /// <summary>The continent.</summary>
        private Continent continent;

        #endregion

        #region Public Methods and Operators

        /// <summary>The continent test_ continent dimensions reflects input.</summary>
        [Test]
        [Category("continents.json")]
        public void ContinentTest_ContinentDimensionsReflectsInput()
        {
            Size expected = default(Size);
            Size actual = this.continent.ContinentDimensions;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The continent test_ continent name reflects input.</summary>
        [Test]
        [Category("continents.json")]
        public void ContinentTest_ContinentNameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.continent.ContinentName;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The continent test_ extension data is empty.</summary>
        [Test]
        [Category("continents.json")]
        [Category("ExtensionData")]
        public void ContinentTest_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.continent.ExtensionData);
        }

        /// <summary>The continent test_ floors reflects input.</summary>
        [Test]
        [Category("continents.json")]
        public void ContinentTest_FloorsReflectsInput()
        {
            var expected = new FloorCollection();
            FloorCollection actual = this.continent.Floors;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The continent test_ maximum zoom reflects input.</summary>
        [Test]
        [Category("continents.json")]
        public void ContinentTest_MaximumZoomReflectsInput()
        {
            const int expected = default(int);
            int actual = this.continent.MaximumZoom;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The continent test_ minimum zoom reflects input.</summary>
        [Test]
        [Category("continents.json")]
        public void ContinentTest_MinimumZoomReflectsInput()
        {
            const int expected = default(int);
            int actual = this.continent.MinimumZoom;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"continent_dims\":[],\"min_zoom\":0,\"max_zoom\":0,\"floors\":[]}";
            this.continent = JsonConvert.DeserializeObject<Continent>(input);
        }

        #endregion
    }
}