// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="RecipeFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="RecipeFlags"/>.</summary>
    internal sealed class ConverterForRecipeFlag : IConverter<string, RecipeFlags>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="RecipeFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RecipeFlags Convert(string value)
        {
            Contract.Assume(value != null);
            RecipeFlags result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(RecipeFlags);
        }
    }
}