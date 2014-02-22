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
using GW2DotNET.V1.Core.ColorsInformation.Details;
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

            var dyesDetailsResult = response.Deserialize();

            Assert.IsNotNull(dyesDetailsResult.Colors);
            Assert.IsNotEmpty(dyesDetailsResult.Colors);

            Assert.IsEmpty(dyesDetailsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DyesDetailsResult).FullName);

            foreach (var dyeDetails in dyesDetailsResult.Colors.Values)
            {
                Assert.IsEmpty(dyeDetails.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DyeDetails).FullName);
                Assert.IsEmpty(dyeDetails.Cloth.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dyeDetails.Leather.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
                Assert.IsEmpty(dyeDetails.Metal.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Material).FullName);
            }

            Trace.WriteLine(string.Format("Number of dyes: {0}", dyesDetailsResult.Colors.Count));
        }
    }
}
