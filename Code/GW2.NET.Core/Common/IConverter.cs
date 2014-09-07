// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for classes that convert one type to another type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Common
{
    /// <summary>Provides the interface for classes that convert one type to another type.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public interface IConverter<in TInput, out TOutput>
    {
        /// <summary>Converts the given <see cref="TInput"/>.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="TOutput"/>.</returns>
        TOutput Convert(TInput value);
    }
}