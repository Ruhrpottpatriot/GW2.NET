// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemTypeTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item type test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details
{
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backpacks;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Bags;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.CraftingMaterials;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.MiniPets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trophies;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The item type test.</summary>
    [TestFixture]
    public class ItemTypeTest
    {
        /// <summary>The item type_ armor_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Armor_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Armor\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Armor>(item);
        }

        /// <summary>The item type_ back_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Back_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Back\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Backpack>(item);
        }

        /// <summary>The item type_ bag_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Bag_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Bag\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Bag>(item);
        }

        /// <summary>The item type_ consumable_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Consumable_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Consumable\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Consumable>(item);
        }

        /// <summary>The item type_ container_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Container_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Container\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Container>(item);
        }

        /// <summary>The item type_ crafting material_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_CraftingMaterial_TypeReflectsInput()
        {
            const string input = "{\"type\":\"CraftingMaterial\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<CraftingMaterial>(item);
        }

        /// <summary>The item type_ gathering_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Gathering_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Gathering\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<GatheringTool>(item);
        }

        /// <summary>The item type_ gizmo_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Gizmo_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Gizmo\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Gizmo>(item);
        }

        /// <summary>The item type_ mini pet_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_MiniPet_TypeReflectsInput()
        {
            const string input = "{\"type\":\"MiniPet\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<MiniPet>(item);
        }

        /// <summary>The item type_ tool_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Tool_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Tool\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Tool>(item);
        }

        /// <summary>The item type_ trinket_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Trinket_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Trinket\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Trinket>(item);
        }

        /// <summary>The item type_ trophy_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Trophy_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Trophy\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Trophy>(item);
        }

        /// <summary>The item type_ upgrade component_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_UpgradeComponent_TypeReflectsInput()
        {
            const string input = "{\"type\":\"UpgradeComponent\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<UpgradeComponent>(item);
        }

        /// <summary>The item type_ weapon_ type reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemType_Weapon_TypeReflectsInput()
        {
            const string input = "{\"type\":\"Weapon\"}";
            var item = JsonConvert.DeserializeObject<Item>(input);

            Assert.IsInstanceOf<Weapon>(item);
        }
    }
}