// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCraftingDiscipline.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="CraftingDisciplines" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Recipes;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="CraftingDisciplines"/>.</summary>
    internal sealed class ConverterForCraftingDiscipline : IConverter<string, CraftingDisciplines>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="CraftingDisciplines"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CraftingDisciplines Convert(string value)
        {
            Contract.Assume(value != null);
            CraftingDisciplines result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(CraftingDisciplines);
        }
    }
}