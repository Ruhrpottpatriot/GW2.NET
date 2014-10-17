// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for serialization engines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.Diagnostics.Contracts;
    using System.IO;

    /// <summary>Provides the interface for serialization engines.</summary>
    /// <typeparam name="T">The serialization type.</typeparam>
    [ContractClass(typeof(SerializerContracts<>))]
    public interface ISerializer<T>
    {
        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        T Deserialize(Stream stream);

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        void Serialize(T value, Stream stream);
    }
}