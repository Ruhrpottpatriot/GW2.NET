// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details
{
    using GW2DotNET.V1.Core.Items.Details.ItemTypes;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The item test.</summary>
    [TestFixture]
    public class ItemTest
    {
        /// <summary>The item.</summary>
        private Item item;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"item_id\":\"0\",\"name\":\"\",\"description\":\"\",\"type\":\"Unknown\",\"level\":\"0\",\"rarity\":\"Unknown\",\"vendor_value\":\"0\",\"icon_file_id\":\"0\",\"icon_file_signature\":\"\",\"game_types\":[],\"flags\":[],\"restrictions\":[]}";
            this.item = JsonConvert.DeserializeObject<UnknownItem>(input);
        }

        /// <summary>The item_ description reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_DescriptionReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.Description;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Item_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.item.ExtensionData);
        }

        /// <summary>The item_ flags reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_FlagsReflectsInput()
        {
            const ItemFlags expected = default(ItemFlags);
            ItemFlags actual = this.item.Flags;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ game types reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_GameTypesReflectsInput()
        {
            const GameRestrictions expected = default(GameRestrictions);
            GameRestrictions actual = this.item.GameTypes;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ icon file id reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_IconFileIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.IconFileId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ icon file signature reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_IconFileSignatureReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.IconFileSignature;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ item id reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_ItemIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.ItemId;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ level reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.Level;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ name reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.Name;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ rarity reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_RarityReflectsInput()
        {
            const ItemRarity expected = default(ItemRarity);
            ItemRarity actual = this.item.Rarity;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_RestrictionsReflectsInput()
        {
            const ItemRestrictions expected = default(ItemRestrictions);
            ItemRestrictions actual = this.item.Restrictions;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_TypeReflectsInput()
        {
            const ItemType expected = default(ItemType);
            ItemType actual = this.item.Type;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The item_ vendor value reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void Item_VendorValueReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.VendorValue;

            Assert.AreEqual(expected, actual);
        }
    }
}