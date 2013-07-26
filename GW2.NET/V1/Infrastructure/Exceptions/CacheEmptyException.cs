// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheEmptyException.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The cache empty exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace GW2DotNET.V1.Infrastructure.Exceptions
{
    /// <summary>The cache empty exception.</summary>
    [Serializable]
    public class CacheEmptyException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="CacheEmptyException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public CacheEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CacheEmptyException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The Exception that is the cause of the current exception, 
        /// or a null reference if no inner exception is specified.</param>
        public CacheEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CacheEmptyException"/> class.</summary>
        /// <param name="info">The info.</param>
        /// <param name="ctxt">The context.</param>
        protected CacheEmptyException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }
    }
}
