// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterAdapter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an adapter for the <see cref="IConverter{TInput,TOutput}" /> interface that does not do any conversions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Converters
{
    /// <summary>Represents an adapter for the <see cref="IConverter{TInput,TOutput}"/> interface that does not do any conversions.</summary>
    /// <typeparam name="T">The type of the value that needs to be adapted.</typeparam>
    public sealed class ConverterAdapter<T> : IConverter<T, T>
    {
        /// <inheritdoc />
        T IConverter<T, T>.Convert(T value, object state)
        {
            return value;
        }
    }
}