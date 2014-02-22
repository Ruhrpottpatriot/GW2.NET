// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Build.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Build type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.BuildInformation;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class BuildTests
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetBuildNumber()
        {
            var request  = new BuildRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var build    = response.DeserializeResponse();

            Assert.IsNotNull(build);

            Assert.IsEmpty(build.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Build).FullName);

            Trace.WriteLine(string.Format("Build: {0}", build.BuildId));
        }

        [Test]
        public async void GetBuildNumberAsync()
        {
            var request  = new BuildRequest();
            var response = await request.GetResponseAsync(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var build    = response.DeserializeResponse();

            Assert.IsNotNull(build);

            Assert.IsEmpty(build.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Build).FullName);

            Trace.WriteLine(string.Format("Build: {0}", build.BuildId));
        }
    }
}
