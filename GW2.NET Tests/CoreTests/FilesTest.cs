// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesTest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FilesTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.FilesInformation.Catalogs;
using GW2DotNET.V1.RestSharp;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    public class FilesTest
    {
        private IServiceClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ServiceClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetFiles()
        {
            var request = new FilesRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var assets = response.Deserialize();

            Assert.IsNotNull(assets);
            Assert.IsNotEmpty(assets);
            Assert.IsEmpty(assets.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Assets).FullName);

            foreach (var pair in assets)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Asset).FullName);
            }

            Trace.WriteLine(string.Format("Number of Assets: {0}", assets.Count));
        }
    }
}