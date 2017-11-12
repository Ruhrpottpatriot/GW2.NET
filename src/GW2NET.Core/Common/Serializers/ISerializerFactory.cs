// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerializerFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for serialization engine factories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    /// <summary>Provides the interface for serialization engine factories.</summary>
    public interface ISerializerFactory
    {
        /// <summary>Gets a serializer for the specified type.</summary>
        /// <typeparam name="T">The serialization type.</typeparam>
        /// <returns>The <see cref="ISerializer{T}"/>.</returns>
        ISerializer<T> GetSerializer<T>();
    }
}
