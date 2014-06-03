// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Backs
{
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backs;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The back test.</summary>
    [TestFixture]
    public class BackTest
    {
        /// <summary>TODO The back.</summary>
        private Back back;

        /// <summary>TODO The back_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Back_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.back.ExtensionData);
        }

        /// <summary>TODO The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"back\":{}}";

            this.back = JsonConvert.DeserializeObject<Back>(input);
        }
    }
}