// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The consumable test.</summary>
    [TestFixture]
    public class ConsumableTest
    {
        /// <summary>TODO The consumable.</summary>
        private Consumable consumable;

        /// <summary>TODO The consumable_ details references source item.</summary>
        [Test]
        [Category("item_details.json")]
        public void Consumable_DetailsReferencesSourceItem()
        {
            var expected = this.consumable;
            var actual = this.consumable.Details.Consumable;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>TODO The consumable_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Consumable_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.consumable.ExtensionData);
        }

        /// <summary>TODO The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"consumable\":{}}";

            this.consumable = JsonConvert.DeserializeObject<Consumable>(input);
        }
    }
}