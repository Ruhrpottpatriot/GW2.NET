// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColourTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ColorsInformation;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class ColorTests
    {

        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create();
        }

        [Test]
        public void GetColors()
        {
            var request  = new ColorsRequest(SupportedLanguages.English);
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var colorsResult = response.Deserialize();

            Assert.IsNotNull(colorsResult.Colors);
            Assert.IsNotEmpty(colorsResult.Colors);

            Assert.IsEmpty(colorsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ColorsResult).FullName);

            foreach (var pair in colorsResult.Colors)
            {
                var dye = pair.Value;

                Assert.IsEmpty(dye.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Dye).FullName);
                Assert.IsEmpty(dye.Cloth.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dye.Leather.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dye.Metal.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
            }

            Trace.WriteLine(string.Format("Number of dyes: {0}", colorsResult.Colors.Count));
        }

        [Test]
        public async void GetColorsAsync()
        {
            var request  = new ColorsRequest(SupportedLanguages.English);
            var response = await request.GetResponseAsync(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var colorsResult = response.Deserialize();

            Assert.IsNotNull(colorsResult.Colors);
            Assert.IsNotEmpty(colorsResult.Colors);

            Assert.IsEmpty(colorsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ColorsResult).FullName);

            foreach (var pair in colorsResult.Colors)
            {
                var dye = pair.Value;

                Assert.IsEmpty(dye.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Dye).FullName);
                Assert.IsEmpty(dye.Cloth.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dye.Leather.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dye.Metal.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
            }

            Trace.WriteLine(string.Format("Number of dyes: {0}", colorsResult.Colors.Count));
        }
    }
}
