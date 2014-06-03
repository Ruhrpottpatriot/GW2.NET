// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackpackTest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   TODO The backpack test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Backs
{
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backpacks;

    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>TODO The backpack test.</summary>
    [TestFixture]
    public class BackpackTest
    {
        /// <summary>TODO The backpack.</summary>
        private Backpack backpack;

        /// <summary>TODO The backpack_ extension data is empty.</summary>
        [Test]
        [Category("item_details.json")]
        [Category("ExtensionData")]
        public void Backpack_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.backpack.ExtensionData);
        }

        /// <summary>TODO The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"item_id\":\"0\",\"back\":{}}";

            this.backpack = JsonConvert.DeserializeObject<Backpack>(input);
        }
    }
}