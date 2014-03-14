// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Containers
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    [TestFixture]
    public class ContainerTest
    {
        private Container container;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"container\":{}}";

            this.container = JsonConvert.DeserializeObject<Container>(input);
        }

        [Test]
        [Category("item_details.json")]
        public void Container_DetailsReferencesSourceItem()
        {
            var expected = this.container;
            var actual = this.container.Details.Container;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Container_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.container.ExtensionData);
        }
    }
}