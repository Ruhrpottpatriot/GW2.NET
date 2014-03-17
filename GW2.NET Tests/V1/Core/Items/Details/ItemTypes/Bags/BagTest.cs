// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Bags
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The bag test.</summary>
    [TestFixture]
    public class BagTest
    {
        /// <summary>TODO The bag.</summary>
        private Bag bag;

        /// <summary>TODO The bag_ details references source item.</summary>
        [Test]
        [Category("item_details.json")]
        public void Bag_DetailsReferencesSourceItem()
        {
            var expected = this.bag;
            var actual = this.bag.Details.Bag;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>TODO The bag_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Bag_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.bag.ExtensionData);
        }

        /// <summary>TODO The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"bag\":{}}";

            this.bag = JsonConvert.DeserializeObject<Bag>(input);
        }
    }
}