// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackTest.cs" company="">
//   
// </copyright>
// <summary>
//   The item test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Backs
{
    using Newtonsoft.Json;

    using NUnit.Framework;

    [TestFixture]
    public class BackTest
    {
        private Back back;

        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"back\":{}}";

            this.back = JsonConvert.DeserializeObject<Back>(input);
        }

        [Test]
        [Category("item_details.json")]
        public void Back_DetailsReferencesSourceItem()
        {
            var expected = this.back;
            var actual = this.back.Details.Back;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Back_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.back.ExtensionData);
        }
    }
}