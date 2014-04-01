// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Containers
{
    using GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Containers;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The container test.</summary>
    [TestFixture]
    public class ContainerTest
    {
        /// <summary>TODO The container.</summary>
        private Container container;

        /// <summary>TODO The container_ details references source item.</summary>
        [Test]
        [Category("item_details.json")]
        public void Container_DetailsReferencesSourceItem()
        {
            var expected = this.container;
            var actual = this.container.Details.Container;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>TODO The container_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Container_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.container.ExtensionData);
        }

        /// <summary>TODO The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"container\":{}}";

            this.container = JsonConvert.DeserializeObject<Container>(input);
        }
    }
}