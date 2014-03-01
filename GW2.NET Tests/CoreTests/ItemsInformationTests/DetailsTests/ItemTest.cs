using GW2DotNET.V1.Core.ItemsInformation.Details;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests.ItemsInformationTests.DetailsTests
{
    [TestFixture]
    public class ItemTest
    {
        private Item item;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"1\",\"name\":\"Test Item\",\"description\":\"Testing.\",\"type\":\"Unknown\",\"level\":\"80\",\"rarity\":\"Junk\",\"vendor_value\":\"1\",\"icon_file_id\":\"10000\",\"icon_file_signature\":\"11A11A111A11AA1A11A11A1111A11111AAA1AA11\",\"game_types\":[\"Activity\",\"Dungeon\",\"PvE\",\"WvW\"],\"flags\":[\"SoulbindOnAcquire\",\"SoulBindOnUse\"],\"restrictions\":[]}";
            this.item = JsonConvert.DeserializeObject<UnknownItem>(input);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_ItemIdReflectsInput()
        {
            const int expectedId = 1;
            Assert.AreEqual(expectedId, this.item.ItemId);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_NameReflectsInput()
        {
            const string expectedName = "Test Item";
            Assert.AreEqual(expectedName, this.item.Name);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_DescriptionReflectsInput()
        {
            const string expectedDescription = "Testing.";
            Assert.AreEqual(expectedDescription, this.item.Description);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_TypeReflectsInput()
        {
            const ItemType expectedItemType = ItemType.Unknown;
            Assert.AreEqual(expectedItemType, this.item.Type);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_LevelReflectsInput()
        {
            const int expectedLevel = 80;
            Assert.AreEqual(expectedLevel, this.item.Level);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_RarityReflectsInput()
        {
            const ItemRarity expectedItemRarity = ItemRarity.Junk;
            Assert.AreEqual(expectedItemRarity, this.item.Rarity);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_VendorValueReflectsInput()
        {
            const int expectedVendorValue = 1;
            Assert.AreEqual(expectedVendorValue, this.item.VendorValue);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_IconFileIdReflectsInput()
        {
            const int expectedIconFileId = 10000;
            Assert.AreEqual(expectedIconFileId, this.item.IconFileId);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_IconFileSignatureReflectsInput()
        {
            const string expectedIconFileSignature = "11A11A111A11AA1A11A11A1111A11111AAA1AA11";
            Assert.AreEqual(expectedIconFileSignature, this.item.IconFileSignature);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_GameTypesReflectsInput()
        {
            const GameTypes expectedGameTypes = GameTypes.Activity | GameTypes.Dungeon | GameTypes.PvE | GameTypes.WvW;
            Assert.AreEqual(expectedGameTypes, this.item.GameTypes);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_FlagsReflectsInput()
        {
            const ItemFlags expectedItemFlags = ItemFlags.SoulBindOnAcquire | ItemFlags.SoulBindOnUse;
            Assert.AreEqual(expectedItemFlags, this.item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void Item_RestrictionsReflectsInput()
        {
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.None;
            Assert.AreEqual(expectedItemRestrictions, this.item.Restrictions);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Item_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.item.ExtensionData);
        }
    }
}
