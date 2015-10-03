// <copyright file="ITypeConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET
{
    using GW2NET.Common;

    /// <summary>Provides the interface for converter factories that create a type converter for a given type discriminator.</summary>
    public interface ITypeConverterFactory<TSource, TTarget>
    {
        /// <summary>Creates an object that can convert the source type to the target type.</summary>
        /// <param name="discriminator">A type discriminator that is used to select the right converter.</param>
        /// <returns>An object that can convert the specified type.</returns>
        IConverter<TSource, TTarget> Create(string discriminator);
    }
}