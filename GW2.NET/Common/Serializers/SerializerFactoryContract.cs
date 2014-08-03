// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerFactoryContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The serializer factory contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Serializers
{
    using System.Diagnostics.Contracts;

    /// <summary>The serializer factory contract.</summary>
    [ContractClassFor(typeof(ISerializerFactory))]
    internal abstract class SerializerFactoryContract : ISerializerFactory
    {
        /// <summary>Gets a serializer for the specified type.</summary>
        /// <typeparam name="T">The serialization type.</typeparam>
        /// <returns>The <see cref="ISerializer{T}"/>.</returns>
        public ISerializer<T> GetSerializer<T>()
        {
            Contract.Ensures(Contract.Result<ISerializer<T>>() != null);
            throw new System.NotImplementedException();
        }
    }
}