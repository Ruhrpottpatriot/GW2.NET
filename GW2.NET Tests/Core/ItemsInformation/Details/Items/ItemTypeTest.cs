// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemTypeTest.cs" company="">
//   
// </copyright>
// <summary>
//    The item type test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.ItemsInformation.Details.Items
{
    using GW2DotNET.V1.Core.ItemsInformation.Details;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.BackPieces;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Bags;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Containers;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.CraftingMaterials;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gizmos;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.MiniPets;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Tools;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trophies;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.UpgradeComponents;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The item type test.</summary>
    [TestFixture]
    public class ItemTypeTest
    {
        #region Public Methods and Operators

        /// <summary>The item type_ armor_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Armor_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Armor\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Armor;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Armor>(item);
        }

        /// <summary>The item type_ back_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Back_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Back\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Back;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Back>(item);
        }

        /// <summary>The item type_ bag_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Bag_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Bag\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Bag;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Bag>(item);
        }

        /// <summary>The item type_ consumable_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Consumable_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Consumable\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Consumable;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Consumable>(item);
        }

        /// <summary>The item type_ container_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Container_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Container\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Container;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Container>(item);
        }

        /// <summary>The item type_ crafting material_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_CraftingMaterial_TypeReflectsInput()
        {
            const string input = "{\"type\":\"CraftingMaterial\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.CraftingMaterial;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<CraftingMaterial>(item);
        }

        /// <summary>The item type_ gathering_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Gathering_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Gathering\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Gathering;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<GatheringTool>(item);
        }

        /// <summary>The item type_ gizmo_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Gizmo_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Gizmo\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Gizmo;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Gizmo>(item);
        }

        /// <summary>The item type_ mini pet_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_MiniPet_TypeReflectsInput()
        {
            const string input = "{\"type\":\"MiniPet\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.MiniPet;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<MiniPet>(item);
        }

        /// <summary>The item type_ tool_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Tool_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Tool\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Tool;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Tool>(item);
        }

        /// <summary>The item type_ trinket_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Trinket_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Trinket\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Trinket;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Trinket>(item);
        }

        /// <summary>The item type_ trophy_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Trophy_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Trophy\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Trophy;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Trophy>(item);
        }

        /// <summary>The item type_ upgrade component_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_UpgradeComponent_TypeReflectsInput()
        {
            const string input = "{\"type\":\"UpgradeComponent\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.UpgradeComponent;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<UpgradeComponent>(item);
        }

        /// <summary>The item type_ weapon_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Weapon_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Weapon\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);
            const ItemType expectedItemType = ItemType.Weapon;

            Assert.AreEqual(expectedItemType, item.Type);
            Assert.IsInstanceOf<Weapon>(item);
        }

        #endregion
    }
}