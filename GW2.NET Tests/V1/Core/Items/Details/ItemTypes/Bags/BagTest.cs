// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackTest.cs" company="">
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

    [TestFixture]
    public class BagTest
    {
        private Bag bag;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"bag\":{}}";

            this.bag = JsonConvert.DeserializeObject<Bag>(input);
        }

        [Test]
        [Category("item_details.json")]
        public void Back_BagDetailsBagIsThis()
        {
            var expected = this.bag;
            var actual = this.bag.BagDetails.Bag;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Back_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.bag.ExtensionData);
        }
    }
}