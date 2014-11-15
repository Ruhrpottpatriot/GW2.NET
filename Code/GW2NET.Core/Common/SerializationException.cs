// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationException.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   TODO The serialization exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;

    /// <summary>TODO The serialization exception.</summary>
    public class SerializationException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="SerializationException"/> class.</summary>
        public SerializationException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SerializationException"/> class.</summary>
        /// <param name="message">TODO The message.</param>
        public SerializationException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SerializationException"/> class.</summary>
        /// <param name="message">TODO The message.</param>
        /// <param name="inner">TODO The inner.</param>
        public SerializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}