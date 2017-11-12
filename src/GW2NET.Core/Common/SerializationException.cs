// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationException.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents errors that occur during (de-)serialization of types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;

    /// <summary>Represents errors that occur during (de-)serialization of types.</summary>
    public sealed class SerializationException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="SerializationException" /> class.</summary>
        public SerializationException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SerializationException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public SerializationException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SerializationException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual
        ///     Basic) if no inner exception is specified.
        /// </param>
        public SerializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
