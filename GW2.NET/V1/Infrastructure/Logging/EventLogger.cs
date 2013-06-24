// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLogger.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The logging framework.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace GW2DotNET.V1.Infrastructure.Logging
{
    using System.IO;

    /// <summary>The logging framework.</summary>
    public class EventLogger
    {
        /// <summary>The trace source.</summary>
        private readonly TraceSource traceSource;

        /// <summary>The complete listener.</summary>
        private readonly TextWriterTraceListener completeListener;

        /// <summary>The random number gen.</summary>
        private readonly Random randomNumberGen;

        /// <summary>The warnings log path.</summary>
        private string warningsLog;

        /// <summary>The complete log path.</summary>
        private string completeLog;

        /// <summary>Initializes a new instance of the <see cref="EventLogger"/> class.</summary>
        public EventLogger()
        {
            this.SetLogFilePaths();

            // Create a new instance of the trace source object.
            this.traceSource = new TraceSource("GW2.NET");

            // Create a new instance of the random number generator.
            this.randomNumberGen = new Random();

            // Create a new Text writer
            // ToDo: Create a way for users to specify the output type of the logs.
            var warningsListener = new TextWriterTraceListener(this.warningsLog);

            this.completeListener = new TextWriterTraceListener(this.completeLog);

            // Create a SourceSwitch and set the initial level of error logging.
            this.traceSource.Switch = new SourceSwitch("mySwitch", "All");

            // Set additional TraceOutput options
            warningsListener.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Timestamp;

            this.completeListener.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Timestamp;

            // Add the listeners to the traceSource.
            this.traceSource.Listeners.Clear();
            this.traceSource.Listeners.Add(warningsListener);
            this.traceSource.Listeners.Add(this.completeListener);

            // Set AutoFlush to true so log files get updated automatically.
            Trace.AutoFlush = true;

            // Create the filters for the log files.
            warningsListener.Filter = new EventTypeFilter(SourceLevels.Warning);
            this.completeListener.Filter = new EventTypeFilter(SourceLevels.All);
        }

        /// <summary>Gets the complete log file path.</summary>
        public string CompleteLogFilePath
        {
            get
            {
                return Path.GetFullPath(this.completeLog);
            }
        }

        /// <summary>Gets the error log file path.</summary>
        public string ErrorLogFilePath
        {
            get
            {
                return Path.GetFullPath(this.warningsLog);
            }
        }

        /// <summary>Gets the log file directory.</summary>
        public string LogFileDirectory
        {
            get
            {
                return Path.GetDirectoryName(this.warningsLog);
            }
        }

        /// <summary>The change logging level.</summary>
        /// <param name="loggingLevel">The new logging level.</param>
        public void ChangeLoggingLevel(SourceLevels loggingLevel)
        {
            this.completeListener.Filter = new EventTypeFilter(loggingLevel);
        }

        /// <summary>The write to log.</summary>
        /// <param name="message">The message.</param>
        /// <param name="eventType">The event type.</param>
        public void WriteToLog(string message, TraceEventType eventType)
        {
            this.traceSource.TraceEvent(eventType, this.RandomNumber(), message);
        }

        /// <summary>The write to log.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="eventType">The event type.</param>
        public void WriteToLog(Exception exception, TraceEventType eventType)
        {
            var message = string.Format("{0}, Additional Details: {1}, Stack Trace: {2}",
                exception.Message,
                exception.InnerException,
                exception.StackTrace);

            this.traceSource.TraceEvent(eventType, this.RandomNumber(), message);
        }

        /// <summary>Sets the log file paths.</summary>
        private void SetLogFilePaths()
        {
            // Get the AppData/Roaming and create the log file path.
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            this.warningsLog = appData + "\\GW2.NET\\Logs\\warnings.log";

            this.completeLog = appData + "\\GW2.NET\\Logs\\complete.log";
        }

        /// <summary>Generates a random umber to use as a event id.</summary>
        /// <returns>The random number as <see cref="int"/>.</returns>
        private int RandomNumber()
        {
            return this.randomNumberGen.Next();
        }
    }
}
