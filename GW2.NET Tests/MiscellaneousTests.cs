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

    using GW2DotNET.V1.Infrastructure.Logging;

    /// <summary>
    /// The miscellaneous tests.
    /// </summary>
    [TestFixture]
    public class MiscellaneousTests
    {
        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
        }

        /// <summary>The logging test.</summary>
        [Test]
        public void LoggingTest()
        {
            var loggingFramework = new Logger();

            loggingFramework.WriteToLog(new NotImplementedException("This function was not implemented yet!", new NotImplementedException()), TraceEventType.Critical);
            
            loggingFramework.WriteToLog("Some Information", TraceEventType.Information);

            loggingFramework.ChangeLoggingLevel(SourceLevels.Critical);

            loggingFramework.WriteToLog(new NotImplementedException("This function was not implemented yet!", new NotImplementedException()), TraceEventType.Critical);

            loggingFramework.WriteToLog("Some Information", TraceEventType.Information);

            Debug.WriteLine(loggingFramework.CompleteLogFilePath);
        }

        /// <summary>
        /// Gets the build number from the api.
        /// </summary>
        [Test]
        public void GetBuildNumber()
        {
            var buildNumber = ApiCall.Build;

            Debug.WriteLine("Build: {0}", buildNumber);
        }
    }
}
