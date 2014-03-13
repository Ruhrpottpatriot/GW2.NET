// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables
{
    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Bags;

    using Newtonsoft.Json;

    using NUnit.Framework;

    [TestFixture]
    public class ConsumableTest
    {
        private Consumable consumable;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"consumable\":{}}";

            this.consumable = JsonConvert.DeserializeObject<Consumable>(input);
        }

        [Test]
        [Category("item_details.json")]
        public void Consumable_DetailsReferencesSourceItem()
        {
            var expected = this.consumable;
            var actual = this.consumable.ConsumableDetails.Consumable;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Consumable_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.consumable.ExtensionData);
        }
    }
}