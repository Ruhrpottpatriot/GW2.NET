// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictionsTest.cs" company="">
//   
// </copyright>
// <summary>
//    The item restrictions test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Core.ItemsInformation.Details.Items
{
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Unknown;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>The item restrictions test.</summary>
    [TestFixture]
    public class ItemRestrictionsTest
    {
        #region Public Methods and Operators

        /// <summary>The item restrictions_ asura_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Asura_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Asura\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Asura;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ charr_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Charr_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Charr\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Charr;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ elementalist_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Elementalist_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Elementalist\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Elementalist;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ engineer_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Engineer_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Engineer\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Engineer;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ guardian_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Guardian_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Guardian\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Guardian;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ human_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Human_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Human\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Human;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ mesmer_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Mesmer_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Mesmer\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Mesmer;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ multiple_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Multiple_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Guardian\",\"Warrior\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Guardian | ItemRestrictions.Warrior;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ necromancer_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Necromancer_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Necromancer\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Necromancer;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ none_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_None_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.None;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ norn_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Norn_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Norn\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Norn;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ ranger_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Ranger_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Ranger\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Ranger;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ sylvari_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Sylvari_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Sylvari\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Sylvari;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ thief_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Thief_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Thief\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Thief;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        /// <summary>The item restrictions_ warrior_ restrictions reflects input.</summary>
        [Test]
        [Category("item_details.json")]
        public void ItemRestrictions_Warrior_RestrictionsReflectsInput()
        {
            const string input = "{\"restrictions\":[\"Warrior\"]}";
            var item = JsonConvert.DeserializeObject<UnknownItem>(input);
            const ItemRestrictions expectedItemRestrictions = ItemRestrictions.Warrior;

            Assert.AreEqual(expectedItemRestrictions, item.Restrictions);
        }

        #endregion
    }
}