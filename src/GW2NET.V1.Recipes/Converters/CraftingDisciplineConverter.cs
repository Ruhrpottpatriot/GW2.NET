// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingDisciplineConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="CraftingDisciplines" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="CraftingDisciplines"/>.</summary>
    public sealed class CraftingDisciplineConverter : IConverter<string, CraftingDisciplines>
    {
        /// <inheritdoc />
        public CraftingDisciplines Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            CraftingDisciplines result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(CraftingDisciplines);
        }
    }
}