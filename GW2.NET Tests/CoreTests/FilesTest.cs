// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Files.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Files type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Files;
using GW2DotNET.V1.Core.Files.Models;

using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    public class FilesTest
    {
        private IApiClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ApiClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetFiles()
        {
            FilesRequest request = new FilesRequest();

            FilesResponse response = request.GetResponse(this.client).DeserializeResponse();

            Assets assets = response.Files;

            Assert.IsNotNull(assets);
            Assert.IsNotEmpty(assets);

            Assert.IsEmpty(assets.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Assets).FullName);

            foreach (var pair in assets)
            {
                Assert.IsEmpty(pair.Value.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Asset).FullName);
            }

            Trace.WriteLine(string.Format("Number of Assets: {0}", assets.Count));
        }

        [Test]
        public async void GetFilesAsync()
        {
            FilesRequest request = new FilesRequest();

            FilesResponse response = (await request.GetResponseAsync(this.client)).DeserializeResponse();

            Assets assets = response.Files;

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