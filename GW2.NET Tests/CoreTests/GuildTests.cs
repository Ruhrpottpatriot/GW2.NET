// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Build type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.GuildInformation;
using GW2DotNET.V1.Core.GuildInformation.Details;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class GuildTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetGuildDetails_ByName()
        {
            var request  = new GuildDetailsRequest("Veterans Of Lions Arch");
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var guild = response.Deserialize();

            Assert.IsNotNull(guild);

            Assert.IsEmpty(guild.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(GuildDetails).FullName);

            Trace.WriteLine(string.Format("Guild tag: {0}", guild.GuildTag));
        }
    }
}
