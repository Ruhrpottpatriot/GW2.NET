// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiscellaneousTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The miscellaneous tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using NUnit.Framework;

namespace GW2.NET_Tests
{
    using System;
    using GW2DotNET.V1;

    /// <summary>
    /// The miscellaneous tests.
    /// </summary>
    [TestFixture]
    public class MiscellaneousTests
    {
        /// <summary>The api manager.</summary>
        private ApiManager apiManager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.apiManager = new ApiManager();
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

            Trace.WriteLine(this.apiManager.Logger.CompleteLogFilePath);
        }

        /// <summary>
        /// Gets the build number from the api.
        /// </summary>
        [Test]
        public void GetBuildNumber()
        {
            Trace.WriteLine(string.Format("Build: {0}", this.apiManager.Build));

            Trace.WriteLine(string.Format("New Build: {0}", this.apiManager.GetLatestBuild()));
        }
    }
}
