// <copyright file="IConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Converters
{
    /// <summary>Provides the interface for classes that convert one type to another type.</summary>
    /// <typeparam name="TSource">The type of the value to convert.</typeparam>
    /// <typeparam name="TTarget">The type of the converted value.</typeparam>
    public interface IConverter<in TSource, out TTarget>
    {
        /// <summary>Converts the given object of type <typeparamref name="TSource"/> to an object of type <typeparamref name="TTarget"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state">An object containing specific information relevant to the conversion, or a null reference.</param>
        /// <exception cref="System.ArgumentNullException">The value to convert is a null reference, or the value of <paramref name="state"/> is a null reference and <paramref name="state"/> is required to convert the given value.</exception>
        /// <exception cref="System.ArgumentException">The value can't be converted by the current converter.</exception>
        /// <returns>The converted value.</returns>
        TTarget Convert(TSource value, object state = null);
    }
}