// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.GuildInformation.Details;
using GW2DotNET.V1.RestSharp;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class GuildTests
    {
        private IServiceClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ServiceClient.Create(new Version(1, 0));
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

        [Test]
        public void GetGuildDetails_ById()
        {
            var request  = new GuildDetailsRequest(Guid.Parse("75FD83CF-0C45-4834-BC4C-097F93A487AF"));
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
