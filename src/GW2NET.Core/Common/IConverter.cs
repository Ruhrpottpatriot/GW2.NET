// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for classes that convert one type to another type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;

    /// <summary>Provides the interface for classes that convert one type to another type.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public interface IConverter<in TInput, out TOutput>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state">An object containing specific information relevant to the conversion, or a null reference.</param>
        /// <exception cref="ArgumentNullException">The value to convert is a null reference, or the value of <paramref name="state"/> is a null reference and <paramref name="state"/> is required to convert the given value.</exception>
        /// <exception cref="ArgumentException">The value can't be converted by the current converter.</exception>
        /// <returns>The converted value.</returns>
        TOutput Convert(TInput value, object state);
    }
}