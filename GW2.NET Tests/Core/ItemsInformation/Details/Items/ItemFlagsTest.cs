using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GW2DotNET.Core.ItemsInformation.Details.Items
{
    [TestFixture]
    public class ItemFlagsTest
    {
        [Test]
        [Category("item_details.json")]
        public void ItemFlags_AccountBound_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"AccountBound\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.AccountBound;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_HideSuffix_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"HideSuffix\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.HideSuffix;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_Multiple_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"SoulBindOnAcquire\",\"SoulBindOnUse\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.SoulBindOnAcquire | ItemFlags.SoulBindOnUse;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_NoMysticForge_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"NoMysticForge\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.NoMysticForge;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_NoSalvage_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"NoSalvage\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.NoSalvage;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_NoSell_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"NoSell\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.NoSell;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_NoUnderwater_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"NoUnderwater\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.NoUnderwater;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_None_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.None;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_NotUpgradeable_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"NotUpgradeable\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.NotUpgradeable;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_SoulBindOnAcquire_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"SoulBindOnAcquire\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.SoulBindOnAcquire;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_SoulBindOnUse_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"SoulBindOnUse\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.SoulBindOnUse;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }

        [Test]
        [Category("item_details.json")]
        public void ItemFlags_Unique_FlagsReflectsInput()
        {
            const string input = "{\"flags\":[\"Unique\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemFlags expectedItemFlags = ItemFlags.Unique;

            Assert.AreEqual(expectedItemFlags, item.Flags);
        }
    }
}