// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Core.ItemsInformation.Details.Items.Armors
{
    using GW2DotNET.V1.Core.ItemsInformation.Details;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors.Unknown;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The armor test.</summary>
    [TestFixture]
    public class ArmorTest
    {
        /// <summary>The armor.</summary>
        private Armor armor;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"armor\":{}}";

            this.armor = JsonConvert.DeserializeObject<Armor>(input);
        }

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
    }
}