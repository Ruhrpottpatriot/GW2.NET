// <copyright file="ISerializer.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common.Serializers
{
    using System;
    using System.IO;

    /// <summary>Provides the interface for serialization engines.</summary>
    /// <typeparam name="T">The serialization type.</typeparam>
    public interface ISerializer<T>
    {
        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="stream"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The input stream is not readable.</exception>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        /// <returns>An instance of the specified type.</returns>
        T Deserialize(Stream stream);

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="value"/> or the value of <paramref name="stream"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The output stream is not writable.</exception>
        /// <exception cref="SerializationException">A serialization error occurred.</exception>
        void Serialize(T value, Stream stream);
    }
}