// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventsTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DynamicEventsTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.DynamicEventsInformation;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details;
using GW2DotNET.V1.Core.DynamicEventsInformation.Names;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class DynamicEventsTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetDynamicEventNames()
        {
            var request = new DynamicEventNamesRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var dynamicEventNames = response.Deserialize();

            Assert.IsNotNull(dynamicEventNames);
            Assert.IsNotEmpty(dynamicEventNames);
            Assert.IsEmpty(dynamicEventNames.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEventNames).FullName);

            foreach (var dynamicEvent in dynamicEventNames)
            {
                Assert.IsEmpty(dynamicEvent.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEventName).FullName);
            }

            Trace.WriteLine(string.Format("Number of dynamic events: {0}", dynamicEventNames.Count));
        }

        [Test]
        public void GetDynamicEventDetails()
        {
            Guid eventId = Guid.Parse("EED8A79F-B374-4AE6-BA6F-B7B98D9D7142");
            var request  = new DynamicEventDetailsRequest(eventId);
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var dynamicEventDetailsResult = response.Deserialize();

            Assert.IsNotNull(dynamicEventDetailsResult);
            Assert.IsNotEmpty(dynamicEventDetailsResult.EventDetails);
            Assert.IsEmpty(dynamicEventDetailsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEventDetailsResult).FullName);

            foreach (var dynamicEvent in dynamicEventDetailsResult.EventDetails)
            {
                Assert.IsEmpty(dynamicEvent.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEventDetails).FullName);
            }
        }

        [Test]
        public void GetDynamicEventStatus()
        {
            int worldId  = 1022;
            int mapId    = 20;
            var request  = new DynamicEventStatusRequest(worldId, mapId);
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var dynamicEventsResult = response.Deserialize();

            Assert.IsNotNull(dynamicEventsResult);
            Assert.IsNotEmpty(dynamicEventsResult.Events);
            Assert.IsEmpty(dynamicEventsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEventsResult).FullName);

            foreach (var dynamicEvent in dynamicEventsResult.Events)
            {
                Assert.IsEmpty(dynamicEvent.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(DynamicEvent).FullName);
            }

            Trace.WriteLine(string.Format("Number of events: {0}", dynamicEventsResult.Events.Count));
        }



    }
}
