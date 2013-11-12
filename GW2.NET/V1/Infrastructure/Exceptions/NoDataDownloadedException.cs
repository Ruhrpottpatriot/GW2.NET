// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoDataDownloadedException.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the NoDataDownloadedException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace GW2DotNET.V1.Infrastructure.Exceptions
{
    /// <summary>
    /// Represents an error that occurs,
    /// if the user tries to access data that is not yet downloaded.
    /// </summary>
    /// <remarks>
    /// This exception is used to signalize the user,
    /// that he tries to access a property that has no data in it
    /// and he should call the data fetching method first.
    /// This is done to keep the property access time as small as possible.
    /// </remarks>
    [Serializable]
    public class NoDataDownloadedException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="NoDataDownloadedException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public NoDataDownloadedException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NoDataDownloadedException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The Exception that is the cause of the current exception, 
        /// or a null reference if no inner exception is specified.</param>
        public NoDataDownloadedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NoDataDownloadedException"/> class.</summary>
        /// <param name="info">The info.</param>
        /// <param name="ctxt">The context.</param>
        protected NoDataDownloadedException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }
    }
}
