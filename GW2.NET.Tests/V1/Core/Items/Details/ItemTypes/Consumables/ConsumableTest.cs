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
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The consumable test.</summary>
    [TestFixture]
    public class ConsumableTest
    {
        /// <summary>TODO The consumable.</summary>
        private Consumable consumable;

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