// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForObject.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:object" /> to objects of type <see cref="T" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Converters
{
    using System.Diagnostics.Contracts;

    /// <summary>Converts objects of type <see cref="T:object"/> to objects of type <see cref="T"/>.</summary>
    /// <typeparam name="T">The type to activate.</typeparam>
    internal sealed class ConverterForObject<T> : IConverter<object, T>
        where T : new()
    {
        /// <inheritdoc />
        T IConverter<object, T>.Convert(object value)
        {
            Contract.Assume(value != null);
            return new T();
        }
    }
}