// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingDisciplineCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="CraftingDisciplines" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="CraftingDisciplines"/>.</summary>
    public sealed class CraftingDisciplineCollectionConverter : IConverter<ICollection<string>, CraftingDisciplines>
    {
        
        private readonly IConverter<string, CraftingDisciplines> craftingDisciplineConverter;

        /// <summary>Initializes a new instance of the <see cref="CraftingDisciplineCollectionConverter"/> class.</summary>
        /// <param name="craftingDisciplineConverter">The converter for <see cref="CraftingDisciplines"/></param>
        public CraftingDisciplineCollectionConverter(IConverter<string, CraftingDisciplines> craftingDisciplineConverter)
        {
            if (craftingDisciplineConverter == null)
            {
                throw new ArgumentNullException("craftingDisciplineConverter");
            }

            this.craftingDisciplineConverter = craftingDisciplineConverter;
        }

        /// <inheritdoc />
        public CraftingDisciplines Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            CraftingDisciplines result = default(CraftingDisciplines);
            foreach (var s in value)
            {
                result |= this.craftingDisciplineConverter.Convert(s, state);
            }

            return result;
        }
    }
}