// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiscellaneousTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The miscellaneous tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

using GW2DotNET.V1.Infrastructure;

using NUnit.Framework;

namespace GW2.NET_Tests
{
    using System;
    using System.Linq;

    using GW2DotNET.V1;
    using GW2DotNET.V1.Infrastructure.Logging;
    using GW2DotNET.V1.Maps.DataProvider;

    /// <summary>
    /// The miscellaneous tests.
    /// </summary>
    [TestFixture]
    public class MiscellaneousTests
    {
        private Gw2ApiManager apiManager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.apiManager = new Gw2ApiManager();
        }

        /// <summary>The logging test.</summary>
        [Test]
        public void LoggingTest()
        {
            this.apiManager.Logger.WriteToLog(new NotImplementedException("This function was not implemented yet!", new NotImplementedException()), TraceEventType.Critical);

            this.apiManager.Logger.WriteToLog("Some Information", TraceEventType.Information);

            this.apiManager.Logger.ChangeLoggingLevel(SourceLevels.Critical);

            this.apiManager.Logger.WriteToLog(new NotImplementedException("This function was not implemented yet!", new NotImplementedException()), TraceEventType.Critical);

            this.apiManager.Logger.WriteToLog("Some Information", TraceEventType.Information);

            Debug.WriteLine(this.apiManager.Logger.CompleteLogFilePath);
        }

        /// <summary>
        /// Gets the build number from the api.
        /// </summary>
        [Test]
        public void GetBuildNumber()
        {
            Debug.WriteLine("Build: {0}", this.apiManager.Build);

            Debug.WriteLine("New Build: {0}", this.apiManager.GetLatestBuild());
        }
    }
}
