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
using GW2DotNET.V1.Core.Build;
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
            BuildRequest request = new BuildRequest();

            BuildResponse response = request.GetResponse(client).DeserializeResponse();

            int build = response.BuildId;

            Assert.IsNotNull(build);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(BuildResponse).FullName);

            Trace.WriteLine(string.Format("Build: {0}", build));
        }

        [Test]
        public async void GetBuildNumberAsync()
        {
            BuildRequest request = new BuildRequest();

            BuildResponse response = (await request.GetResponseAsync(client)).DeserializeResponse();

            int build = response.BuildId;

            Assert.IsNotNull(build);

            Assert.IsEmpty(response.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(BuildResponse).FullName);

            Trace.WriteLine(string.Format("Build: {0}", build));
        }
    }
}
