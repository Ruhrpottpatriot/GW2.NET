// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="RecipeFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="RecipeFlags"/>.</summary>
    public sealed class RecipeFlagCollectionConverter : IConverter<ICollection<string>, RecipeFlags>
    {
        private readonly IConverter<string, RecipeFlags> recipeFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="RecipeFlagCollectionConverter"/> class.</summary>
        /// <param name="recipeFlagConverter">The converter for <see cref="RecipeFlags"/>.</param>
        public RecipeFlagCollectionConverter(IConverter<string, RecipeFlags> recipeFlagConverter)
        {
            this.recipeFlagConverter = recipeFlagConverter;
        }

        /// <inheritdoc />
        public RecipeFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            RecipeFlags result = default(RecipeFlags);
            foreach (var s in value)
            {
                result |= this.recipeFlagConverter.Convert(s, state);
            }

            return result;
        }
    }
}