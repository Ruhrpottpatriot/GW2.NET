// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventLogger.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The EventLogger interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2DotNET.V1.Infrastructure.Logging
{
    using System;

    /// <summary>The EventLogger interface.</summary>
    public interface IEventLogger
    {
        /// <summary>Gets the log file directory.</summary>
        string LogFileDirectory { get; }

        /// <summary>The write to log.</summary>
        /// <param name="message">The message.</param>
        /// <param name="eventType">The event type.</param>
        void WriteToLog(string message, TraceEventType eventType);

        /// <summary>The write to log.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="eventType">The event type.</param>
        void WriteToLog(Exception exception, TraceEventType eventType);

        /// <summary>The change logging level.</summary>
        /// <param name="newLoggingLevel">The new logging level.</param>
        void ChangeLoggingLevel(SourceLevels newLoggingLevel);
    }
}