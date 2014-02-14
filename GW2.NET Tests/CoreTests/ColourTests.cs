// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColourTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColourTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Colors;
using GW2DotNET.V1.Core.Colors.Models;

using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    class ColourTests
    {
        [Test]
        public void GetColours()
        {
            ColorsRequest colorsRequest = new ColorsRequest(SupportedLanguages.English);

            ColorsResponse colorsResponse = colorsRequest.GetResponse(ApiClient.Create()).DeserializeResponse();

            IDictionary<int, Dye> colours = colorsResponse.Colors;

            Assert.IsNotNull(colours);
            Assert.IsNotEmpty(colours);
        }

        [Test]
        public async void GetColoursAsync()
        {
            ColorsRequest request = new ColorsRequest(SupportedLanguages.English);

            ColorsResponse colorsResponse = (await request.GetResponseAsync(ApiClient.Create())).DeserializeResponse();

            IDictionary<int, Dye> colours = colorsResponse.Colors;

            Assert.IsNotNull(colours);
            Assert.IsNotEmpty(colours);
        }

        [Test]
        public void GetColoursGerman()
        {

            ColorsRequest request = new ColorsRequest(SupportedLanguages.German);

            ColorsResponse colorsResponse = request.GetResponse(ApiClient.Create()).DeserializeResponse();

            IDictionary<int, Dye> colours = colorsResponse.Colors;

            Assert.IsNotNull(colours);
            Assert.IsNotEmpty(colours);
        }

        [Test]
        public void GetColoursFrench()
        {

            ColorsRequest request = new ColorsRequest(SupportedLanguages.French);

            ColorsResponse colorsResponse = request.GetResponse(ApiClient.Create()).DeserializeResponse();

            IDictionary<int, Dye> colours = colorsResponse.Colors;

            Assert.IsNotNull(colours);
            Assert.IsNotEmpty(colours);
        }

        [Test]
        public void GetColoursSpanish()
        {

            ColorsRequest request = new ColorsRequest(SupportedLanguages.Spanish);

            ColorsResponse colorsResponse = request.GetResponse(ApiClient.Create()).DeserializeResponse();

            IDictionary<int, Dye> colours = colorsResponse.Colors;

            Assert.IsNotNull(colours);
            Assert.IsNotEmpty(colours);
        }
    }
}
