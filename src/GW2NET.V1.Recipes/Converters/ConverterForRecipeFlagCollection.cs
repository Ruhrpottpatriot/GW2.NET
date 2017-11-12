// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="RecipeFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2NET.Common;
using GW2NET.Recipes;

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="RecipeFlags"/>.</summary>
    internal sealed class ConverterForRecipeFlagCollection : IConverter<ICollection<string>, RecipeFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, RecipeFlags> converterForRecipeFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeFlagCollection"/> class.</summary>
        internal ConverterForRecipeFlagCollection()
            : this(new ConverterForRecipeFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeFlagCollection"/> class.</summary>
        /// <param name="converterForRecipeFlag">The converter for <see cref="RecipeFlags"/>.</param>
        internal ConverterForRecipeFlagCollection(IConverter<string, RecipeFlags> converterForRecipeFlag)
        {
            this.converterForRecipeFlag = converterForRecipeFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="RecipeFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RecipeFlags Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            RecipeFlags result = default(RecipeFlags);
            foreach (var s in value)
            {
                result |= this.converterForRecipeFlag.Convert(s);
            }

            return result;
        }
    }
}