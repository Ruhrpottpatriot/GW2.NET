using GW2DotNET.V1.Core.ItemsInformation.Details;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ItemsInformation.Details
{
    [TestFixture]
    public class ItemTest
    {
        [SetUp]
        public void Initialize()
        {
            const string input =
                "{\"item_id\":\"0\",\"name\":\"\",\"description\":\"\",\"type\":\"Unknown\",\"level\":\"0\",\"rarity\":\"Unknown\",\"vendor_value\":\"0\",\"icon_file_id\":\"0\",\"icon_file_signature\":\"\",\"game_types\":[],\"flags\":[],\"restrictions\":[]}";
            this.item = JsonConvert.DeserializeObject<UnknownItem>(input);
        }

        private Item item;

        [Test]
        [Category("item_details.json")]
        public void Item_DescriptionReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.Description;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Item_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.item.ExtensionData);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_FlagsReflectsInput()
        {
            const ItemFlags expected = default(ItemFlags);
            ItemFlags actual = this.item.Flags;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_GameTypesReflectsInput()
        {
            const GameTypes expected = default(GameTypes);
            GameTypes actual = this.item.GameTypes;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_IconFileIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.IconFileId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_IconFileSignatureReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.IconFileSignature;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_ItemIdReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.ItemId;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_LevelReflectsInput()
        {
            const int expected = default(int);
            int actual = this.item.Level;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.item.Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_RarityReflectsInput()
        {
            const ItemRarity expected = default(ItemRarity);
            ItemRarity actual = this.item.Rarity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_RestrictionsReflectsInput()
        {
            const ItemRestrictions expected = default(ItemRestrictions);
            ItemRestrictions actual = this.item.Restrictions;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_TypeReflectsInput()
        {
            const ItemType expected = default(ItemType);
            ItemType actual = this.item.Type;

            Assert.AreEqual(expected, actual);
        }

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