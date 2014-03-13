// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Armors
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The armor test.</summary>
    [TestFixture]
    public class ArmorTest
    {
        /// <summary>The armor.</summary>
        private Armor armor;

        [Test]
        [Category("item_details.json")]
        public void Armor_ArmorDetailsReflectsInput()
        {
            var expected = this.armor;
            var actual = this.armor.ArmorDetails.Armor;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Armor_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.armor.ExtensionData);
        }

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"armor\":{}}";

            this.armor = JsonConvert.DeserializeObject<Armor>(input);
        }
    }
}