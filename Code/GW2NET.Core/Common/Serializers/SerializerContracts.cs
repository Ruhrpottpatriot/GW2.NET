// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The serializer contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.Diagnostics.Contracts;
    using System.IO;

    /// <summary>The serializer contracts.</summary>
    /// <typeparam name="T">The serialization type.</typeparam>
    [ContractClassFor(typeof(ISerializer<>))]
    internal abstract class SerializerContracts<T> : ISerializer<T>
    {
        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            Contract.Requires(stream != null);
            Contract.Requires(stream.CanRead);
            throw new System.NotImplementedException();
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(T value, Stream stream)
        {
            Contract.Requires(stream != null);
            Contract.Requires(stream.CanWrite);
            throw new System.NotImplementedException();
        }
    }
}